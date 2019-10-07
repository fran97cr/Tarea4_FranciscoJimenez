using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sem4.Modelo;

namespace Sem4
{
    public partial class index : System.Web.UI.Page
    {
        #region Definición de variables
        PERSONA objPersona = new PERSONA();
        PERSONA objBuscado;
        //Variables utilizadas para el metodo de consultar
        static string resulNom;
        static string resulApe1;
        static string resulApe2;
        static string resulID;
        #endregion


        void RegistrarPersona()
        {
            #region CreateDB
            try
            {
                //se llama al contexto de la BD
                using (ContextoBDUIA contexto = new ContextoBDUIA())
                {

                   //se guardan en el objeto los respectivos atributos
                    objPersona.Identificación = txtIdentifiacion.Text;
                    objPersona.nomPersona = txtNomPersona.Text;
                    objPersona.Ape1Persona = txtApe1Persona.Text;
                    objPersona.Ape2Persona = txtApe2Persona.Text;
                    //se llama al contexto se le agrega el objeto y se salvan los cambios en la BD
                    contexto.PERSONA.Add(objPersona);
                    contexto.SaveChanges();
                }
                ScriptManager.RegisterClientScriptBlock(this,this.GetType(),"Mensaje","Swal.fire('Se registro con exito')",true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mensaje", "Swal.fire('"+ex.InnerException.InnerException.Message.Substring(0,35)+"')", true);
               
            }
            #endregion
        }

       

        void EliminarPersona(string pIdentificacion)
        {
            #region DeleteDB
            try
            {
                using (ContextoBDUIA contextoBD = new ContextoBDUIA())
                {
                    //se realiza el filtro
                     objBuscado = contextoBD.PERSONA.Where(c => c.Identificación == pIdentificacion).FirstOrDefault();

                    if (objBuscado != null)
                    {
                        //se elimina al registro
                        contextoBD.PERSONA.Remove(objBuscado);
                    }
                    //se guardan los cambios en la BD
                    contextoBD.SaveChanges();
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mesanje", "Swal.fire('Se elimino de forma correcta')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mesanje", "Swal.fire('" + ex.InnerException.InnerException.Message.Substring(0, 35) + "')", true);

            }
            #endregion

        }


        void ActualizarPersona(string pIdentificacion)
        {
            #region UpdateDB
            try
            {
                using (ContextoBDUIA contextoBD = new ContextoBDUIA())
                {
                    // se realiza el filtro
                     objBuscado = contextoBD.PERSONA.Where(c => c.Identificación == pIdentificacion).FirstOrDefault();
                    
                    if (objBuscado != null)
                    {
                        // se realizan las modificaciones
                        objBuscado.nomPersona = txtNomPersona.Text;
                        objBuscado.Ape1Persona = txtApe1Persona.Text;
                        objBuscado.Ape2Persona = txtApe2Persona.Text;
                    }
                    // se guardan los cambios en la BD
                    contextoBD.SaveChanges();
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mesanje", "Swal.fire('Se actualizo de forma correcta')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mesanje", "Swal.fire('" + ex.InnerException.InnerException.Message.Substring(0, 35) + "')", true);

            }
            #endregion

        }

        void ConsultarPersona(string pIdentificacion/*,string ResulNombre, string ResulApe1, string ResulApe2*/)
        {
            #region ReadDB
            try
            {
                using (ContextoBDUIA contextoBD = new ContextoBDUIA())
                {
                    //se llama con el filtro al primer resultado 
                    objBuscado = contextoBD.PERSONA.Where(c => c.Identificación == pIdentificacion).FirstOrDefault();
                    if (objBuscado != null)
                    {
                        // se guarda en las variables estaticas globales
                        resulNom = objBuscado.nomPersona;
                        resulApe1 = objBuscado.Ape1Persona;
                        resulApe2 = objBuscado.Ape2Persona;
                    }
                    contextoBD.SaveChanges();
                }

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mesanje", "Swal.fire('Se encontro un resultado con el identificador proporcionado')", true);
            }
                
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Mesanje", "Swal.fire('" + ex.InnerException.InnerException.Message.Substring(0, 35) + "')", true);

            }
            #endregion
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            //se llama al registro que realiza el ingreso del cliente
            RegistrarPersona();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //se llama al metodo que realiza la actalizacion del registro en particular
            ActualizarPersona(txtIdentifiacion.Text);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //se llama al metodo que realiza la eliminacion del registro en particular
            EliminarPersona(txtIdentifiacion.Text);
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            //variable obtiene el id a buscar
            resulID = txtIdentifiacion.Text;
            //se llama al metodo que realiza la consulta
            ConsultarPersona(resulID);
            // se dibuja en los respectivos campos 
            lblIdResul.Text = resulID;
            lblNomResul.Text = resulNom;
            lblApe1Resul.Text = resulApe1;
            lblApe2Resul.Text = resulApe2;
        }
    }
}