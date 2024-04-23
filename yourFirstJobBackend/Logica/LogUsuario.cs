﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using yourFirstJobBackend.AccesoDatos;
using yourFirstJobBackend.Entidades.entities;
using yourFirstJobBackend.Entidades.Request;
using yourFirstJobBackend.Entidades.Response;

namespace yourFirstJobBackend.Logica
{
    public class LogUsuario
    {
        //Ingresar Usuario
        public ResIngresarUsuario IngresarUsuario(ReqIngresarUsuario req)

        {
            ResIngresarUsuario res = new ResIngresarUsuario();

            try
            {
                res.resultado = false;
                res.listaDeErrores = new List<string>();

                // Validación de los campos del usuario
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Request nulo");
                }
                else
                {
                    if (req == null)
                    {
                        res.resultado=false;
                        res.listaDeErrores.Add("No se encuentra el usuario");
                    }
                    if (String.IsNullOrEmpty(req.usuario.nombreUsuario))
                    {
                        res.listaDeErrores.Add("Nombre de usuario faltante");
                    }
                    if (String.IsNullOrEmpty(req.usuario.apellidos))
                    {
                        res.listaDeErrores.Add("No se ingreso los apellidos");
                    }
                    if (String.IsNullOrEmpty(req.usuario.correo))
                    {
                        res.listaDeErrores.Add("No se ingreso el correo");
                    }
                    if (req.usuario.telefono == 0)
                    {
                        res.listaDeErrores.Add("No se ingreso el numero de telefono");
                    }
                    if (req.usuario.fechaNacimiento == DateTime.MinValue)
                    {
                        res.listaDeErrores.Add("No se ingreso la fecha de nacimiento");
                    }
                    if (req.usuario.idRegion == 0)
                    {
                        res.listaDeErrores.Add("No se ingreso id de region");
                    }
                    if (String.IsNullOrEmpty(req.usuario.contrasena))
                    {
                        res.listaDeErrores.Add("No se ingreso la contrasena");
                    }
                    
                }

                // Si no hay errores de validación, intenta insertar el usuario en la base de datos
                if (res.listaDeErrores.Any())
                {
                    res.resultado = false;
                }
                else { 
                    LinqDataContext conexion = new LinqDataContext();
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = "";
                    bool estado = true;

                    Utilitarios utl = new Utilitarios();

                    conexion.InsertUsuario(req.usuario.nombreUsuario, req.usuario.apellidos, req.usuario.correo, req.usuario.telefono,
                        req.usuario.fechaNacimiento, req.usuario.idRegion, utl.encriptar(req.usuario.contrasena), estado, ref errorId, ref errorDescripcion, ref idReturn);

                    if (idReturn == 0)
                    {
                        //Error en base de datos

                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                        res.resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            finally
            {
                //Bitacora 
            }
            return res;
        }

        //Ingresar Idioma
        public ResIngresarIdiomaUsuario IngresarIdiomaUsuario(ReqIngresarIdiomaUsuario req)

        {
            ResIngresarIdiomaUsuario res = new ResIngresarIdiomaUsuario();

            try
            {
                res.resultado = false;
                res.listaDeErrores = new List<string>();

                // Validación
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("No se encuentra el idioma");
                }
                if (req.idUsuario == 0)
                {
                    res.listaDeErrores.Add("Usuario invalido");
                }
                if (req.idIdioma == 0)
                {
                    res.listaDeErrores.Add("Idioma invalido");
                }



                // Si no hay errores de validación, intenta insertar el usuario en la base de datos
                if (res.listaDeErrores.Any())
                {
                    res.resultado = false;
                }
                else
                {
                    LinqDataContext conexion = new LinqDataContext();
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = "";

                    conexion.InsertIdiomasUsuarios(req.idUsuario, req.idIdioma, ref errorId, ref errorDescripcion, ref idReturn);

                    if (idReturn == 0)
                    {
                        //Error en base de datos

                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                        res.resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            finally
            {
                //Bitacora 
            }
            return res;
        }

        //Ingresar Habilidades
        public ResIngresarHabilidadUsuario IngresarHabilidadUsuario(ReqIngresarHabilidadUsuario req)

        {
            ResIngresarHabilidadUsuario res = new ResIngresarHabilidadUsuario();

            try
            {
                res.resultado = false;
                res.listaDeErrores = new List<string>();

                // Validación
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Error en la solicitud");
                }
                if (req.idUsuario == 0)
                {
                    res.listaDeErrores.Add("Usuario invalido");
                }
                if (req.habilidades == null)
                {
                    res.listaDeErrores.Add("Habilidad vacia");
                }



                // Si no hay errores de validación, intenta insertar el usuario en la base de datos
                if (res.listaDeErrores.Any())
                {
                    res.resultado = false;
                }
                else
                {
                    LinqDataContext conexion = new LinqDataContext();
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = "";

                    conexion.InsertHabilidadesUsuarios(req.idUsuario, req.habilidades.idHabilidades, ref errorId, ref errorDescripcion, ref idReturn);

                    if (idReturn == 0)
                    {
                        //Error en base de datos

                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                        res.resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            finally
            {
                //Bitacora 
            }
            return res;
        }

        //Ingresar Estudios
        public ResIngresarEstudioUsuario IngresarEstudioUsuario(ReqIngresarEstudioUsuario req)

        {
            ResIngresarEstudioUsuario res = new ResIngresarEstudioUsuario();

            try
            {
                res.resultado = false;
                res.listaDeErrores = new List<string>();

                // Validación
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Error en la solicitud");
                }
                if (req.idUsuario == 0)
                {
                    res.listaDeErrores.Add("Usuario invalido");
                }
                if (req.estudio == null)
                {
                    res.listaDeErrores.Add("Estudio vacio");
                }



                // Si no hay errores de validación, intenta insertar el usuario en la base de datos
                if (res.listaDeErrores.Any())
                {
                    res.resultado = false;
                }
                else
                {
                    LinqDataContext conexion = new LinqDataContext();
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = "";

                    conexion.InsertEstudiosUsuarios(req.idUsuario, req.estudio.nombreInstitucion, req.estudio.gradoAcademico, req.estudio.profesion.idProfesion, req.estudio.fechaInicio, req.estudio.fechaFinalizacion, ref errorId, ref errorDescripcion, ref idReturn);

                    if (idReturn == 0)
                    {
                        //Error en base de datos

                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                        res.resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            finally
            {
                //Bitacora 
            }
            return res;
        }

        //Ingresar Experiencia
        public ResIngresarExperienciaUsuario IngresarExperienciaUsuario(ReqIngresarExperienciaUsuario req)

        {
            ResIngresarExperienciaUsuario res = new ResIngresarExperienciaUsuario();

            try
            {
                res.resultado = false;
                res.listaDeErrores = new List<string>();

                // Validación
                if (req == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Error en la solicitud");
                }
                if (req.idUsuario == 0)
                {
                    res.listaDeErrores.Add("Usuario invalido");
                }
                if (req.experiencia == null)
                {
                    res.listaDeErrores.Add("Experiencia vacia");
                }



                // Si no hay errores de validación, intenta insertar el usuario en la base de datos
                if (res.listaDeErrores.Any())
                {
                    res.resultado = false;
                }
                else
                {
                    LinqDataContext conexion = new LinqDataContext();
                    int? idReturn = 0;
                    int? errorId = 0;
                    string errorDescripcion = "";

                    conexion.InsertExperienciaUsuarios(req.idUsuario, req.experiencia.profesion.idProfesion, req.experiencia.puesto, req.experiencia.nombreEmpresa, req.experiencia.responsabilidades, req.experiencia.fechaInicio, req.experiencia.fechaFinalizacion, ref errorId, ref errorDescripcion, ref idReturn);

                    if (idReturn == 0)
                    {
                        //Error en base de datos

                        res.resultado = false;
                        res.listaDeErrores.Add(errorDescripcion);
                    }
                    else
                    {
                        res.resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            finally
            {
                //Bitacora 
            }
            return res;
        }

        //Ingresar archvios usuarios
        public ResIngresarArchivosUsuarios ingresarArchivos(ReqIngresarArchivoUsuario req)
        {
            ResIngresarArchivosUsuarios res = new ResIngresarArchivosUsuarios();
            try
            {
                res.resultado = false;
                res.listaDeErrores = new List<string>();

                if (req.idUsuario == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("Request nulo");
                }



                if (req.idUsuario == null)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("No se recibio el usuario");
                }
                if (String.IsNullOrEmpty(req.nombreArchivo))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("no se envio el nombre del archvio");
                }
                if (req.archivo == null || req.archivo.Length == 0)
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("No se recibió el archivo del usuario");
                }

                if (String.IsNullOrEmpty(req.tipo))
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("no se envio el tipo del archvio");
                }


                if (res.listaDeErrores.Any())
                {
                    res.resultado = false;
                }
                else
                {
                    //llamar base de datos 


                    LinqDataContext conexion = new LinqDataContext();
                    int? idReturn = 0;
                    int? errorOcurred = 0;
                    string errorMensaje = "";
                    int? lineasInsertadas = 0;


                    // conexion a SP 

                    conexion.SP_Insertar_ArchivoUsuario(req.idUsuario, req.nombreArchivo, req.archivo, req.tipo, ref errorOcurred, ref errorMensaje);

                    if (errorOcurred != 0)
                    {
                        //Error en base de datos
                        res.resultado = false;
                        res.listaDeErrores.Add(errorMensaje);
                    }
                    else
                    {
                        res.resultado = true;
                    }
                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            finally
            {
                //Bitacora 
            }
            return res;

        }

        //traer un usuario
        public ResObtenerPerfilUsuario obtenerUsuario(ReqObtenerUsuario req)
        {
            ResObtenerPerfilUsuario res = new ResObtenerPerfilUsuario();
            res.listaDeErrores = new List<string>();
            int? errorId = 0;
            string errorDescripcion = "";

            try
            {
                LinqDataContext conexion = new LinqDataContext();

                  SP_InformacionUsuarioResult usuarioBD = conexion.SP_InformacionUsuario(req.idUser, ref errorId, ref errorDescripcion).FirstOrDefault();

                if (usuarioBD != null)
                {
                    //lista 
                    List<Idiomas> listaIdiomas = new List<Idiomas>();
                    List<Habilidades> listaHabilidad = new List<Habilidades>();
                    List<Estudios> listaEstudio = new List<Estudios>();
                    List<ArchivosUsuario> listaArchivoUsuario = new List<ArchivosUsuario>();
                    List<ExperienciaLaboral> listaExperienciaLaboral = new List<ExperienciaLaboral>();
                    res.resultado = true;
                


                    int? errorIdIdiomas = 0;
                    string errorDescripcionIdiomas = "";

                    foreach (var idiomaInfo in conexion.Select_Idiomas_Usuario(usuarioBD.idUsuario, ref errorIdIdiomas, ref errorDescripcionIdiomas)) 
                    {
                        if (errorIdIdiomas == 1)
                        {
                            //Error SP Idiomas
                            res.resultado = false;
                            res.listaDeErrores.Add(errorDescripcionIdiomas);

                        }
                        else
                        {
                            Idiomas idioma = new Idiomas();

                            idioma.idIdioma = idiomaInfo.idIdioma;
                            idioma.idioma = idiomaInfo.idioma;
                            idioma.nivel = idiomaInfo.nivel;

                            listaIdiomas.Add(idioma); // Agrega el idioma a la lista

                        }

                    }

                    int? errorIdHabilidades = 0;
                    string errorDescripcionidHabilidad = "";

                    foreach (var habilidadInfo in conexion.Select_Habilidad_Usuario(usuarioBD.idUsuario, ref errorIdHabilidades, ref errorDescripcionidHabilidad))
                    {
                        if (errorIdHabilidades == 1)
                        {
                            res.resultado = false;
                            res.listaDeErrores.Add(errorDescripcionidHabilidad);

                        }
                        else
                        {
                            Habilidades habilidades = new Habilidades();
                            habilidades.idHabilidades = habilidadInfo.idHabilidades;
                            habilidades.categoria = habilidadInfo.categoria;
                            habilidades.descripcion = habilidadInfo.descripcion;

                            listaHabilidad.Add(habilidades);

                        }

                    }


                    int? errorIdEstudios = 0;
                    string errorDescripcionidEstudios = "";
                    foreach (var EstudiosInfo in conexion.Select_Estudios_Usuario(usuarioBD.idUsuario, ref errorIdEstudios, ref errorDescripcionidEstudios))
                    {
                        if (errorIdEstudios == 1)
                        {
                            res.resultado = false;
                            res.listaDeErrores.Add(errorDescripcionidEstudios);

                        }
                        else
                        {
                            Estudios estudios = new Estudios();
                            estudios.idEstudios = EstudiosInfo.idEstudios;
                            estudios.nombreInstitucion = EstudiosInfo.nombreInstitucion;
                            estudios.gradoAcademico = EstudiosInfo.gradoAcademico;
                            estudios.fechaInicio = EstudiosInfo.fechaInicio;
                            estudios.fechaFinalizacion = EstudiosInfo.fechaFinalizacion;

                            Profesion profesion = new Profesion();
                            profesion.idProfesion = EstudiosInfo.idProfesion;
                            profesion.nombreProfesion = EstudiosInfo.nombreProfesion;
                            profesion.descripcion = EstudiosInfo.descripcion;

                            estudios.profesion = profesion;

                            listaEstudio.Add(estudios);
                        }

                    }


                    int? errorIdArchivosU = 0;
                    string errorDescripcionidArchivosU = "";
                    foreach (var ArchivosInfo in conexion.Select_Archivos_Usuario(usuarioBD.idUsuario, ref errorIdArchivosU, ref errorDescripcionidArchivosU))
                    {
                        if (errorIdEstudios == 1)
                        {
                            res.resultado = false;
                            res.listaDeErrores.Add(errorDescripcionidArchivosU);

                        }
                        else
                        {
                            ArchivosUsuario archivUsuario = new ArchivosUsuario();
                            archivUsuario.idArchivosUsuarios = ArchivosInfo.idArchivosUsuarios;
                            archivUsuario.idUsuario = ArchivosInfo.idUsuario;
                            archivUsuario.nombreArchivo = ArchivosInfo.nombreArchivo;
                            archivUsuario.archivo = ArchivosInfo.archivo.ToArray();
                            archivUsuario.tipo = ArchivosInfo.tipo;

                            listaArchivoUsuario.Add(archivUsuario);
                        }

                    }


                    int? errorIdExLaboral = 0;
                    string errorDescripcionidExLaboral = "";
                    foreach (var ExperienciaInfo in conexion.Select_Experiencia_Laboral(usuarioBD.idUsuario, ref errorIdExLaboral, ref errorDescripcionidExLaboral))
                    {
                        if (errorIdExLaboral == 1)
                        {
                            res.resultado = false;
                            res.listaDeErrores.Add(errorDescripcionidExLaboral);

                        }
                        else
                        {
                            ExperienciaLaboral exLaboral = new ExperienciaLaboral();
                            exLaboral.idExperiencia = ExperienciaInfo.idExperiencia;
                            exLaboral.idUsuario = ExperienciaInfo.idUsuario;
                            exLaboral.puesto = ExperienciaInfo.puesto;
                            exLaboral.nombreEmpresa = ExperienciaInfo.nombreEmpresa;
                            exLaboral.responsabilidades = ExperienciaInfo.responsabilidades;
                            exLaboral.fechaInicio = ExperienciaInfo.fechaInicio;
                            exLaboral.fechaFinalizacion = ExperienciaInfo.fechaFinalizacion;

                            Profesion profesion = new Profesion();
                            profesion.idProfesion = ExperienciaInfo.idProfesion;
                            profesion.nombreProfesion = ExperienciaInfo.nombreProfesion;
                            profesion.descripcion = ExperienciaInfo.descripcion;

                            exLaboral.profesion = profesion;

                            listaExperienciaLaboral.Add(exLaboral);
                        }

                    }
                    res.usuario = this.traerUsuario(usuarioBD, listaIdiomas, listaHabilidad, listaEstudio, listaArchivoUsuario, listaExperienciaLaboral);


                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {
            }

            return res;

        }

        //Login
        public ResLogin loginUser(ReqLogin req)
        {
            ResLogin res = new ResLogin();

            res.listaDeErrores = new List<string>();

            int? errorId = 0;
            int? idReturn = 0;
            string errorDescripcion = "";


            try
            {
                LinqDataContext conexion = new LinqDataContext();

                Utilitarios utl = new Utilitarios();

                Login_UserResult usuarioBD = conexion.Login_User(req.username, utl.encriptar(req.password), ref errorId, ref errorDescripcion, ref idReturn).FirstOrDefault();

                if (usuarioBD != null)
                {
                    //Errores
                    if (errorId != 0)
                    {
                        //Paso un error
                        res.listaDeErrores.Add(errorDescripcion);
                        res.resultado = false;
                    }
                    else if (idReturn == 0)
                    {
                        //Vino vacio el ID Return
                        res.listaDeErrores.Add("Usuario no encontrado");
                        res.resultado = false;
                    }
                    else
                    {
                        //Todo bien
                        Usuario usuario = new Usuario();

                        usuario.idUsuario = usuarioBD.idUsuario;
                        usuario.nombreUsuario = usuarioBD.nombreUsuario;
                        usuario.apellidos = usuarioBD.apellidos;
                        usuario.correo = usuarioBD.correo;

                        res.usuario = usuario;

                        res.resultado = true;
                    }

                }
                else
                {
                    //Null
                    res.listaDeErrores.Add("Usuario nulo");
                    res.resultado = false;

                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }
            return res;
        }

        //Eliminr usuario (en bd se hace update al campo estado =0 para decir q el usuario ya no existe)
        public ResEliminarUsuario eliminarUsuario(ReqEliminarUsuario req)
        {
            ResEliminarUsuario res = new ResEliminarUsuario();
            res.listaDeErrores = new List<string>();
            try
            {
                LinqDataContext conexion = new LinqDataContext();
                 int idUsuario = req.idUsuario;  
                int? errorOccured = 0;
                string errorMessage = "";
                int? lineasActualizadas = 0;


                DesactivarUsuarioResult resultado = conexion.DesactivarUsuario(idUsuario, ref errorOccured, ref errorMessage, ref lineasActualizadas).SingleOrDefault();

                if (resultado != null)
                {
                    res.resultado = true;
                    // res.mensaje = resultado.ErrorMessage; 
                }
                else
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("No se encontró el usuario.");
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            return res;


        }

        //Eliminar idioma
        public ResEliminarIdiomaUsuario eliminarIdiomaUsuario(ReqEliminarIdiomaUsuario req)
        {
            ResEliminarIdiomaUsuario res = new ResEliminarIdiomaUsuario();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();

                int? errorId = 0;
                int? camposActualizados = 0;
                string errorDescripcion = "";
                conexion.DeleteIdiomaUsuario(req.idUsuario, req.idIdioma, ref errorId, ref errorDescripcion, ref camposActualizados);

                if (camposActualizados != 0)
                {
                    //Errores
                    if (errorId != 0)
                    {
                        //Paso un error
                        res.listaDeErrores.Add(errorDescripcion);
                        res.resultado = false;
                    }
                    else
                    {
                        //Todo bien        

                        res.resultado = true;
                    }

                }
                else
                {
                    //Null
                    res.listaDeErrores.Add("Error al delete");
                    res.resultado = false;
                    

                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //Eliminar habilidad
        public ResEliminarHabilidadUsuario eliminarHabilidadUsuario(ReqEliminarHabilidadUsuario req)
        {
            ResEliminarHabilidadUsuario res = new ResEliminarHabilidadUsuario();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();

                int? errorId = 0;
                int? camposActualizados = 0;
                string errorDescripcion = "";
                conexion.DeleteHabilidadUsuario(req.idUsuario, req.idHabilidad, ref errorId, ref errorDescripcion, ref camposActualizados);

                if (camposActualizados != 0)
                {
                    //Errores
                    if (errorId != 0)
                    {
                        //Paso un error
                        res.listaDeErrores.Add(errorDescripcion);
                        res.resultado = false;
                    }
                    else
                    {
                        //Todo bien        

                        res.resultado = true;
                    }

                }
                else
                {
                    //Null
                    res.listaDeErrores.Add("Error al delete");
                    res.resultado = false;


                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //Eliminar estudios
        public ResEliminarEstudioUsuario eliminarEstudioUsuario(ReqEliminarEstudioUsuario req)
        {
            ResEliminarEstudioUsuario res = new ResEliminarEstudioUsuario();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();

                int? errorId = 0;
                int? camposActualizados = 0;
                string errorDescripcion = "";
                conexion.DeleteEstudioUsuario(req.idUsuario, req.idEstudio, ref errorId, ref errorDescripcion, ref camposActualizados);

                if (camposActualizados != 0)
                {
                    //Errores
                    if (errorId != 0)
                    {
                        //Paso un error
                        res.listaDeErrores.Add(errorDescripcion);
                        res.resultado = false;
                    }
                    else
                    {
                        //Todo bien        

                        res.resultado = true;
                    }

                }
                else
                {
                    //Null
                    res.listaDeErrores.Add("Error al delete");
                    res.resultado = false;


                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //Eliminar experienciaLaboral
        public ResEliminarExperienciaUsuario eliminarExperienciaUsuario(ReqEliminarExperienciaUsuario req)
        {
            ResEliminarExperienciaUsuario res = new ResEliminarExperienciaUsuario();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();

                int? errorId = 0;
                int? camposActualizados = 0;
                string errorDescripcion = "";
                conexion.DeleteExperenciaUsuario(req.idUsuario, req.idExperiencia, ref errorId, ref errorDescripcion, ref camposActualizados);

                if (camposActualizados != 0)
                {
                    //Errores
                    if (errorId != 0)
                    {
                        //Paso un error
                        res.listaDeErrores.Add(errorDescripcion);
                        res.resultado = false;
                    }
                    else
                    {
                        //Todo bien        

                        res.resultado = true;
                    }

                }
                else
                {
                    //Null
                    res.listaDeErrores.Add("Error al delete");
                    res.resultado = false;


                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //eliminar un archivo de usuario
        public ResEliminarArchivosUsuarios eliminarArchivoUsuario(ReqEliminarArchivosUsuario req)
        {
            ResEliminarArchivosUsuarios res = new ResEliminarArchivosUsuarios();
            res.listaDeErrores = new List<string>();
            try
            {
                LinqDataContext conexion = new LinqDataContext();
                int? errorOccured = 0;
                string errorMessage = "";
                int? lineasActualizadas = 0;


                conexion.SP_Borrar_ArchivoUsuario(req.idArchivosUsuarios, req.idUsuario, ref errorOccured, ref errorMessage);

                if (errorOccured == 0)
                {
                    res.resultado = true;
                    res.listaDeErrores.Add(errorMessage);
                }
                else
                {
                    res.resultado = false;
                    res.listaDeErrores.Add("No se encontró el archivo.");
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());
            }
            return res;


        }

        //Update usuario
        public ResUpdateUsuario updateUsuario(ReqUpdateUsuario req)
        {
            ResUpdateUsuario res = new ResUpdateUsuario();

            res.listaDeErrores = new List<string>();

            int? errorId = 0;
            int? camposActualizados = 0;
            string errorDescripcion = "";

            try
            {
                LinqDataContext conexion = new LinqDataContext();

                conexion.UpdateUsuario(req.usuario.idUsuario, req.usuario.nombreUsuario, req.usuario.apellidos, req.usuario.correo, req.usuario.telefono, req.usuario.fechaNacimiento, req.usuario.idRegion, req.usuario.sitioWeb, ref errorId, ref errorDescripcion, ref camposActualizados);

                if (camposActualizados != 0)
                {
                    //Errores
                    if (errorId != 0)
                    {
                        //Paso un error
                        res.listaDeErrores.Add(errorDescripcion);
                        res.resultado = false;
                    }
                    else
                    {
                        //Todo bien        

                        res.resultado = true;
                    }

                }
                else
                {
                    //Null
                    res.listaDeErrores.Add("Error al update");
                    res.resultado = false;

                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //Update idiomas
        public ResUpdateUsuarioIdioma updateIdiomasUsuario(List<ReqUpdateUsuarioIdioma> lstReq)
        {
            ResUpdateUsuarioIdioma res = new ResUpdateUsuarioIdioma();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();


                foreach (ReqUpdateUsuarioIdioma cadaUno in lstReq)
                {

                    int? errorId = 0;
                    int? camposActualizados = 0;
                    string errorDescripcion = "";
                    conexion.UpdateIdiomasUsuarios(cadaUno.idUsuario, cadaUno.idIdioma, cadaUno.idIdiomaNuevo, ref errorId, ref errorDescripcion, ref camposActualizados);

                    if (camposActualizados != 0)
                    {
                        //Errores
                        if (errorId != 0)
                        {
                            //Paso un error
                            res.listaDeErrores.Add(errorDescripcion);
                            res.resultado = false;
                        }
                        else
                        {
                            //Todo bien        

                            res.resultado = true;
                        }

                    }
                    else
                    {
                        //Null
                        res.listaDeErrores.Add("Error al update");
                        res.resultado = false;
                        break;

                    }

                }

                

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //Update habilidadesUsuario
        public ResUpdateUsuarioHabilidades updateHabilidadesUsuario(List<ReqUpdateUsuarioHabilidades> lstReq)
        {
            ResUpdateUsuarioHabilidades res = new ResUpdateUsuarioHabilidades();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();


                foreach (ReqUpdateUsuarioHabilidades cadaUno in lstReq)
                {

                    int? errorId = 0;
                    int? camposActualizados = 0;
                    string errorDescripcion = "";
                    conexion.UpdateHabilidadesUsuarios(cadaUno.idUsuario, cadaUno.idHabilidad, cadaUno.idHabilidadNueva, ref errorId, ref errorDescripcion, ref camposActualizados);

                    if (camposActualizados != 0)
                    {
                        //Errores
                        if (errorId != 0)
                        {
                            //Paso un error
                            res.listaDeErrores.Add(errorDescripcion);
                            res.resultado = false;
                        }
                        else
                        {
                            //Todo bien        

                            res.resultado = true;
                        }

                    }
                    else
                    {
                        //Null
                        res.listaDeErrores.Add("Error al update");
                        res.resultado = false;
                        break;

                    }

                }



            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //Update estudios
        public ResUpdateUsuarioEstudios updateEstudiosUsuario(List<ReqUpdateUsuarioEstudios> lstReq)
        {
            ResUpdateUsuarioEstudios res = new ResUpdateUsuarioEstudios();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();


                foreach (ReqUpdateUsuarioEstudios cadaUno in lstReq)
                {

                    int? errorId = 0;
                    int? camposActualizados = 0;
                    string errorDescripcion = "";
                    conexion.UpdateEstudiosUsuarios(cadaUno.idUsuario, cadaUno.estudios.idEstudios, cadaUno.estudios.nombreInstitucion, cadaUno.estudios.gradoAcademico, cadaUno.estudios.profesion.idProfesion, cadaUno.estudios.fechaInicio, cadaUno.estudios.fechaFinalizacion, ref errorId, ref errorDescripcion, ref camposActualizados);

                    if (camposActualizados != 0)
                    {
                        //Errores
                        if (errorId != 0)
                        {
                            //Paso un error
                            res.listaDeErrores.Add(errorDescripcion);
                            res.resultado = false;
                        }
                        else
                        {
                            //Todo bien        

                            res.resultado = true;
                        }

                    }
                    else
                    {
                        //Null
                        res.listaDeErrores.Add("Error al update");
                        res.resultado = false;
                        break;

                    }

                }



            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        //Update experiencia
        public ResUpdateUsuarioExperiencia updateExperienciaUsuario(List<ReqUpdateUsuarioExperiencia> lstReq)
        {
            ResUpdateUsuarioExperiencia res = new ResUpdateUsuarioExperiencia();

            res.listaDeErrores = new List<string>();

            try
            {
                LinqDataContext conexion = new LinqDataContext();


                foreach (ReqUpdateUsuarioExperiencia cadaUno in lstReq)
                {

                    int? errorId = 0;
                    int? camposActualizados = 0;
                    string errorDescripcion = "";
                    conexion.UpdateExperienciaUsuarios(cadaUno.idUsuario, cadaUno.experienciaLaboral.idExperiencia, cadaUno.experienciaLaboral.profesion.idProfesion, cadaUno.experienciaLaboral.puesto, cadaUno.experienciaLaboral.nombreEmpresa, cadaUno.experienciaLaboral.responsabilidades, cadaUno.experienciaLaboral.fechaInicio, cadaUno.experienciaLaboral.fechaFinalizacion, ref errorId, ref errorDescripcion, ref camposActualizados);

                    if (camposActualizados != 0)
                    {
                        //Errores
                        if (errorId != 0)
                        {
                            //Paso un error
                            res.listaDeErrores.Add(errorDescripcion);
                            res.resultado = false;
                        }
                        else
                        {
                            //Todo bien        

                            res.resultado = true;
                        }

                    }
                    else
                    {
                        //Null
                        res.listaDeErrores.Add("Error al update");
                        res.resultado = false;
                        break;

                    }

                }



            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

   

        //actualizar foto de perfil usuario
        public ResActualizarFotoPerfil actualizarFoto(ReqActualizarFotoPerfil req)
        {
            ResActualizarFotoPerfil res = new ResActualizarFotoPerfil();

            res.listaDeErrores = new List<string>();

            int? errorId = 0;
            int? camposActualizados = 0;
            string errorDescripcion = "";

            try
            {
                LinqDataContext conexion = new LinqDataContext();

                conexion.sp_Actualizar_FotoPerfil(req.idUsuario, req.idArchivo, req.archivo, ref errorId, ref errorDescripcion, ref camposActualizados);

                if (camposActualizados != 0)
                {
                    //Errores
                    if (errorId != 0)
                    {
                        //Paso un error
                        res.listaDeErrores.Add(errorDescripcion);
                        res.resultado = false;
                    }
                    else
                    {
                        //Todo bien        

                        res.resultado = true;
                    }

                }
                else
                {
                    //Null
                    res.listaDeErrores.Add("Error al update");
                    res.resultado = false;

                }

            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.listaDeErrores.Add(ex.ToString());

            }
            finally
            {

                //Bitacora

            }

            return res;

        }

        #region

        //factoria traer usuario 
        private Usuario traerUsuario(SP_InformacionUsuarioResult usuarioBD, List<Idiomas>listaIdiomas, List<Habilidades>listaHabilidades, List<Estudios>listaEstudios, List<ArchivosUsuario>listaAchivosUsuario, List<ExperienciaLaboral>listaExperienciaLaboral)
        {
            //entidad usuario
            Usuario usuarioRetornar = new Usuario();

            usuarioRetornar.nombreUsuario = usuarioBD.nombreUsuario;
            usuarioRetornar.apellidos = usuarioBD.apellidos;
            usuarioRetornar.correo = usuarioBD.correo;
            usuarioRetornar.telefono = usuarioBD.telefono;
            usuarioRetornar.fechaNacimiento = usuarioBD.fechaNacimiento;
            usuarioRetornar.sitioWeb = usuarioBD.sitioWeb;
            usuarioRetornar.idRegion = usuarioBD.idRegion;

            Region region = new Region();

            region.idRegion = usuarioBD.idRegion;
            region.nombreRegion = usuarioBD.nombreRegion;

            usuarioRetornar.region = region;

            usuarioRetornar.idUsuario = usuarioBD.idUsuario;
            usuarioRetornar.contrasena = usuarioBD.contrasena;
            usuarioRetornar.listaIdiomas = listaIdiomas;
            usuarioRetornar.listaHabilidades = listaHabilidades;
            usuarioRetornar.listaEstudios = listaEstudios;
            usuarioRetornar.listaArchivosUsuarios = listaAchivosUsuario;
            usuarioRetornar.listaExperienciaLaboral = listaExperienciaLaboral;
            

            if (usuarioBD.estado != null)
            {
                usuarioRetornar.estado = usuarioBD.estado.Value;
            }
            else
            {
                usuarioRetornar.estado = false;
            }

            return usuarioRetornar;


        }

        #endregion
    }
}