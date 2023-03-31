using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetAdminAD.Interfaces;
using VetAdminEN.Clases.Organizacion;
using VetAdminEN.Conexion;

namespace VetAdminAD.Clases
{
    public class PersonaAD : IPersonaAD
    {
        protected readonly VetAdminContext _context;
        public PersonaAD(VetAdminContext vetAdminContext)
        {
            _context = vetAdminContext;
        }

        public async Task<int> Crear(PersonaEN poPersonaEN, int iAccion)
        {
            int iIdPersona;
            using (SqlConnection cnn = _context.Connection())
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("sqORG.sp_CrearPersona", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@piIdPersona", poPersonaEN.iIdPersona);
                        cmd.Parameters.AddWithValue("@pvNombres", poPersonaEN.sNombres);
                        cmd.Parameters.AddWithValue("@pvApellidoPaterno", poPersonaEN.sApellidoPaterno);
                        cmd.Parameters.AddWithValue("@pvApellidoMaterno", poPersonaEN.sApellidoMaterno);
                        cmd.Parameters.AddWithValue("@psiTipoDocumento", poPersonaEN.siTipoDocumento);
                        cmd.Parameters.AddWithValue("@pvNumeroDocumento", poPersonaEN.sNumeroDocumento);
                        cmd.Parameters.AddWithValue("@pvEmail", poPersonaEN.sEmail);
                        cmd.Parameters.AddWithValue("@pvUbigeo", poPersonaEN.sUbigeo);
                        cmd.Parameters.AddWithValue("@pdFechaNacimiento", poPersonaEN.dFechaNacimiento);
                        cmd.Parameters.AddWithValue("@pvDireccion", poPersonaEN.sDireccion);
                        cmd.Parameters.AddWithValue("@piIdUsuarioLogin", poPersonaEN.iIdUsuarioCrea);
                        cmd.Parameters.AddWithValue("@psiAccion", iAccion);
                        object? resultado = await cmd.ExecuteScalarAsync();

                        iIdPersona =  int.Parse(resultado.ToString());

                        cmd.Dispose();
                    }

                    cnn.Close();
                    cnn.Dispose();
                }
                catch (Exception ex)
                {

                    cnn.Close();
                    cnn.Dispose();
                    throw ex;
                }
            }
            return iIdPersona;
        }
        public async Task<PersonaEN> Obtener(int piIdPersona)
        {
            List<PersonaEN> oPersonaEN = await Listar(piIdPersona);

            return oPersonaEN.FirstOrDefault();
        }
        public async Task<List<PersonaEN>> Listar(int piIdPersona = 0)
        {
            List<PersonaEN> loPersonaEN = new List<PersonaEN>();
            PersonaEN oPersonaEN;
            using (SqlConnection cnn = _context.Connection())
            {
                try
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("sqORG.sp_ListarPersona", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@piIdPersona", piIdPersona);

                        SqlDataReader drd = await cmd.ExecuteReaderAsync();
                        while (drd.Read())
                        {
                            oPersonaEN = new PersonaEN();
                            oPersonaEN.sNombres = _context.reader<string>(drd, "vNombres");
                            oPersonaEN.sApellidoPaterno = _context.reader<string>(drd, "vApellidoPaterno");
                            oPersonaEN.sApellidoMaterno = _context.reader<string>(drd, "vApellidoMaterno");
                            oPersonaEN.siTipoDocumento = _context.reader<short>(drd, "siTipoDocumento");
                            oPersonaEN.sNumeroDocumento = _context.reader<string>(drd, "vNumeroDocumento");
                            oPersonaEN.sEmail = _context.reader<string>(drd, "vEmail");
                            oPersonaEN.sUbigeo = _context.reader<string>(drd, "vUbigeo");
                            oPersonaEN.dFechaNacimiento = _context.reader<DateTime>(drd, "dFechaNacimiento");
                            oPersonaEN.sDireccion = _context.reader<string>(drd, "vDireccion");
                            oPersonaEN.sCelular = _context.reader<string>(drd, "vCelular");
                            oPersonaEN.siEstado = _context.reader<short>(drd, "siEstado");
                            oPersonaEN.dtFechaCrea = _context.reader<DateTime>(drd, "dtFechaCrea");
                            oPersonaEN.dtFechaActualiza = _context.reader<DateTime>(drd, "dtFechaActualiza");
                            oPersonaEN.iIdUsuarioCrea = _context.reader<int>(drd, "iIdUsuarioCrea");
                            oPersonaEN.iIdUsuarioActualiza = _context.reader<int>(drd, "iIdUsuarioActualiza");

                            loPersonaEN.Add(oPersonaEN);
                        }
                        cmd.Dispose();
                    }

                    cnn.Close();
                    cnn.Dispose();
                }
                catch (Exception ex)
                {

                    cnn.Close();
                    cnn.Dispose();
                    throw ex;
                }
            }
            return loPersonaEN;
        }
    }
}
