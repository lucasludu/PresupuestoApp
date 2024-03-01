using MiPresupuestoApp.Data;
using MiPresupuestoApp.Models;
using MiPresupuestoApp.Negocio.Interface;

namespace MiPresupuestoApp.Negocio
{
    public class UsuarioNegocio : GenericNegocio<Usuario>, IUsuarioNegocio
    {
        public UsuarioNegocio(Context context) : base(context) 
        {
            
        }
    }
}
