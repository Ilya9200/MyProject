using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EleWise.ELMA.Extensions;
using EleWise.ELMA.Model.Common;
using EleWise.ELMA.Model.Entities;
using EleWise.ELMA.Model.Entities.ProcessContext;
using EleWise.ELMA.Model.Managers;
using EleWise.ELMA.Model.Metadata;
using EleWise.ELMA.Model.Services;
using EleWise.ELMA.Model.Types.Settings;
using EleWise.ELMA.Security.DTO.Models;
using EleWise.ELMA.Security.Managers;
using EleWise.ELMA.Security.Models;
using EleWise.ELMA.Security.Types.Settings;
using EleWise.ELMA.Workflow.BPMN.Diagrams.Elements.Swimlanes;
using EleWise.ELMA.Workflow.BPMN.Models;
using EleWise.ELMA.Workflow.Models;
using Context = EleWise.ELMA.Model.Entities.ProcessContext.P_Uluchshenie;

namespace EleWise.ELMA.Model.Scripts
{
    
    /// <summary>
    /// Модуль сценариев процесса "Улучшение"
    /// </summary>
    public class P_Uluchshenie_Scripts : EleWise.ELMA.Workflow.Scripts.ProcessScriptBase<Context>
    {

        public void ProcessOwnerResolver(Context context)
        {
        	var matrixItem = ((IBPMNProcess) context.ImprovedProcessHeader.Published.CastAsRealType()).ResponsibilityMatrix.FirstOrDefault(x => x.ResponsibilityLevel == ResponsibilityLevel.Owner);        	
        	if (matrixItem != null && matrixItem.WorkerId.HasValue)
        	{
        		var settings = (EntityUserSettings)context.GetSettingsFor(c => c.ProcessOwner);
            	settings.Workers.Clear();
            	settings.Workers.Add(new Worker { WorkerId = matrixItem.WorkerId.Value, WorkerType = matrixItem.WorkerType });
            	settings.Save();
        	}
        	else
        	{
        		var admin = (User) UserManager.Instance.Load(Security.SecurityConstants.AdminUserUid);

        		var propMetadata = ((ClassMetadata)MetadataLoader.LoadMetadata(context.GetType())).Properties.First(p => p.Name == "ProcessOwner");
             	var swimlane = context.WorkflowInstance.Process.Diagram.Elements.OfType<SwimlaneElement>().First(s => s.ExecuterProperty == propMetadata.Uid);
             	var swimlaneExecutor = context.WorkflowInstance.SwimlaneExecutors.FirstOrDefault(se => se.SwimlaneUid == swimlane.Uid);
             	if (swimlaneExecutor == null)
             	{
              		swimlaneExecutor = new WorkflowSwimlaneExecutor { SwimlaneUid = swimlane.Uid, WorkflowInstance = context.WorkflowInstance };
              		context.WorkflowInstance.SwimlaneExecutors.Add(swimlaneExecutor);
             	}
             	swimlaneExecutor.User = admin;

        		// исполнитель по-умолчанию
        		context.Worker = admin;asdasd
        	}d

        }       

    }

}
