using MiPresupuestoApp.Data;
using MiPresupuestoApp.Negocio.Repositorio;
using MiPresupuestoApp.Negocio.Repositorio.Interface;
using MiPresupuestoApp.Negocio.UOW.Interface;

namespace MiPresupuestoApp.Negocio.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly Context _context;

        public IUsuarioNegocio Usuario { get; private set; }

        public UnitOfWork(Context context)
        {
            _context = context;
            Usuario = new UsuarioNegocio(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
