namespace InterviewTest;

using Nancy;
using Nancy.TinyIoc;

public class Bootstrapper : DefaultNancyBootstrapper
{
    protected override void ConfigureApplicationContainer(TinyIoCContainer container)
    {
        base.ConfigureApplicationContainer(container);
        container.Register<StudentCollection>().AsSingleton();
        container.Register<TeacherCollection>().AsSingleton();
    }
}
