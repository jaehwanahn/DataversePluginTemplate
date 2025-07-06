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
        // Uncomment the following lines to add input and output arguments to your custom workflow activity.
        //[RequiredArgument]
        //[Input("Decimal input")]
        //public InArgument<decimal> DecInput { get; set; }

        //[Output("Decimal output")]
        //public OutArgument<decimal> DecOutput { get; set; }
        protected override void Execute(CodeActivityContext executionContext)
        {
            // https://learn.microsoft.com/en-us/power-apps/developer/data-platform/workflow/tutorial-create-workflow-extension
            // https://learn.microsoft.com/en-us/power-apps/developer/data-platform/workflow/tutorial-create-workflow-extension
            // https://github.com/microsoft/PowerApps-Samples/tree/master/dataverse/orgsvc/CSharp/WorkflowActivities

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

                // Uncomment the following lines to return the output.
                //DecOutput.Set(executionContext, "Output Value Here");

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
