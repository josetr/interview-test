using Nancy;
using Nancy.TinyIoc;

namespace InterviewTest
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            container.Register<StudentCollection>().AsSingleton();
            container.Register<TeacherCollection>().AsSingleton();
        }
    }
}