using DemoTask.Core;

namespace DemoTask.DI
{
  public class DipendencyInversion
  {
    public static void Injector(IServiceCollection services)
    {
      services.AddScoped<ICrudOperationServices,CrudOperationServices>();
    }
  }
}
