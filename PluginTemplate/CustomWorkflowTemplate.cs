using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;

namespace PluginTemplate
{
    /// <summary>
    /// Custom Workflow Description: Explain what this custom workflow does, what the dependencies are, and how to configure.
    /// </summary>
    public class CustomWorkflowTemplate : CodeActivity
    {
        protected override void Execute(CodeActivityContext executionContext)
        {
            //Create the tracing service
            ITracingService tracingService = executionContext.GetExtension<ITracingService>();

            // Create an Organization Service
            IWorkflowContext context = executionContext.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory serviceFactory = executionContext.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = serviceFactory.CreateOrganizationService(context.InitiatingUserId);

            try
            {
                // Workflow business logic goes here.
                tracingService.Trace("Custom Workflow Started");

                tracingService.Trace("Custom Workflow Stopped");
            }
            catch (Exception ex)
            {
                tracingService.Trace("Custom Workflow: {0}", ex.ToString());
                throw;
            }
        }
    }
}
