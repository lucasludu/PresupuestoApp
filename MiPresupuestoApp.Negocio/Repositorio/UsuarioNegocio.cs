using MiPresupuestoApp.Data;
using MiPresupuestoApp.Models;
using MiPresupuestoApp.Negocio.Repositorio.Interface;

namespace MiPresupuestoApp.Negocio.Repositorio
{
    public class UsuarioNegocio : GenericNegocio<Usuario>, IUsuarioNegocio
    {
        public UsuarioNegocio(Context context) : base(context)
        {

        }
    }
}
