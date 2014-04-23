using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace NancyCsrfDemo
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            Nancy.Security.Csrf.Enable(pipelines);
        }
    }
}