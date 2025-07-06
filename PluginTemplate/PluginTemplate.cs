using Microsoft.Xrm.Sdk;
using System;
using System.ServiceModel;

namespace PluginTemplate
{
    /// <summary>
    /// 
    /// Plugin Description: Explain what this plugin does.
    /// 
    /// Plugin Configuration Details - You need to all details for developers to register plugins such as plugin step, message in Plugin Registration Tool.
    /// 
    /// [Example below]
    /// Primary Entity: systemuser
    /// Required Plugin Steps: Create of systemuser, Update of systemuser
    /// Filtering Attributes: domainname, firstname, lastname
    /// Stage of Execution and Execution Mode: Pre-operation - Synchronous
    /// User's Context: Calling User
    /// Unsecure / Secure Configuration: (Enter the configuration here excluding any sensitive information such as client secret)
    /// (Add more details as needed)
    /// 
    /// </summary>
    public class PluginTemplate : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            // https://learn.microsoft.com/en-us/power-apps/developer/data-platform/tutorial-write-plug-in
            // https://learn.microsoft.com/en-us/power-apps/developer/data-platform/best-practices/business-logic/

            // Obtain the tracing service
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // Obtain the execution context from the service provider.  
            IPluginExecutionContext context = (IPluginExecutionContext) serviceProvider.GetService(typeof(IPluginExecutionContext));

            // The InputParameters collection contains all the data passed in the message request.  
            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                // Obtain the target entity from the input parameters.  
                Entity entity = (Entity)context.InputParameters["Target"];

                // Obtain the IOrganizationService instance which you will need for web service calls.  
                IOrganizationServiceFactory serviceFactory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
                IOrganizationService service = serviceFactory.CreateOrganizationService(context.UserId);

                try
                {
                    // Plug-in business logic goes here.              
                    tracingService.Trace("Plugin Started");


                    tracingService.Trace("Plugin Stopped");
                }

                catch (FaultException<OrganizationServiceFault> ex)
                {
                    throw new InvalidPluginExecutionException("An error occurred in xxx Plugin.", ex);
                }
                catch (Exception ex)
                {
                    tracingService.Trace("Plugin: {0}", ex.ToString());
                    throw;
                }
            }
        }
    }
}
