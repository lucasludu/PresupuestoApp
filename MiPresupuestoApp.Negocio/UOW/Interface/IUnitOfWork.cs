using MiPresupuestoApp.Negocio.Repositorio.Interface;

namespace MiPresupuestoApp.Negocio.UOW.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioNegocio Usuario { get; }

    }
}
