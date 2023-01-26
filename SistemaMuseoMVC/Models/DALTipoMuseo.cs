using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

    public class DALTipoMuseo
    {

        public Boolean insertarTipoMuseo(EntidadTipoMuseo tipoMuseo)
        {

            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();

            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_tipo", tipoMuseo.TipoMuseo_tipo));
            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_descripcion", tipoMuseo.TipoMuseo_descripcion));
            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_estado", tipoMuseo.TipoMuseo_estado));

            cmd.CommandText = "InsertarTipoMuseo";
            cmd.CommandType = CommandType.StoredProcedure;

            int x = cmd.ExecuteNonQuery();
            aux.conectar();

            if (x >= 1)
            {
                return true;
            }
            else
                return false;
        }
        public List<EntidadTipoMuseo> listarTipoMuseo()
        {

            Conectividad aux = new Conectividad();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = aux.conectar();
            cmd.CommandText = "ListarTipoMuseo";

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            List<EntidadTipoMuseo> lista = new List<EntidadTipoMuseo>();

            while (dr.Read())
            {
            EntidadTipoMuseo tipoMuseo = new EntidadTipoMuseo();

                tipoMuseo.TipoMuseo_id = int.Parse(dr["TipoMuseo_id"].ToString());
                tipoMuseo.TipoMuseo_tipo = dr["TipoMuseo_tipo"].ToString();
                tipoMuseo.TipoMuseo_descripcion = dr["TipoMuseo_descripcion"].ToString();
                tipoMuseo.TipoMuseo_estado = dr["TipoMuseo_estado"].ToString();

                lista.Add(tipoMuseo);
            }
            aux.conectar();

            return lista;
        }

    public List<EntidadTipoMuseo> listarInactivo()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarTipoMuseoInactivo";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadTipoMuseo> lista = new List<EntidadTipoMuseo>();

        while (dr.Read())
        {
            EntidadTipoMuseo tipoMuseo = new EntidadTipoMuseo();

            tipoMuseo.TipoMuseo_id = int.Parse(dr["TipoMuseo_id"].ToString());
            tipoMuseo.TipoMuseo_tipo = dr["TipoMuseo_tipo"].ToString();
            tipoMuseo.TipoMuseo_descripcion = dr["TipoMuseo_descripcion"].ToString();
            tipoMuseo.TipoMuseo_estado = dr["TipoMuseo_estado"].ToString();

            lista.Add(tipoMuseo);
        }
        aux.conectar();

        return lista;
    }

    public void modificarTipoMuseo(EntidadTipoMuseo tipoMuseo)
        {
            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();

            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_id", tipoMuseo.TipoMuseo_id));
            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_tipo", tipoMuseo.TipoMuseo_tipo));
            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_descripcion", tipoMuseo.TipoMuseo_descripcion));
            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_estado", tipoMuseo.TipoMuseo_estado));

            cmd.CommandText = "ModificarTipoMuseo";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            aux.conectar();
        }

        public Boolean eliminarTipoMuseo(int TipoMuseo_id)
        {
            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();

            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_id", TipoMuseo_id));

            cmd.CommandText = "InactivarTipoMuseo";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            int x = cmd.ExecuteNonQuery();
            aux.conectar();

            if (x >= 1)
                return true;
            else
                return false;
        }

    public Boolean activarTipoMuseo(int TipoMuseo_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@TipoMuseo_id", TipoMuseo_id));

        cmd.CommandText = "ActivarTipoMuseo";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public EntidadTipoMuseo buscarTipoMuseo(int tipoMuseo_id)
        {
        EntidadTipoMuseo tipoMuseo = new EntidadTipoMuseo();
            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();

            cmd.Parameters.Add(new SqlParameter("@TipoMuseo_id", tipoMuseo.TipoMuseo_id));

            cmd.CommandText = "ConsultarTipoMuseo";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                tipoMuseo.TipoMuseo_id = int.Parse(dr["TipoMuseo_id"].ToString());
                tipoMuseo.TipoMuseo_tipo = dr["TipoMuseo_tipo"].ToString();
                tipoMuseo.TipoMuseo_descripcion = dr["TipoMuseo_descripcion"].ToString();    
                tipoMuseo.TipoMuseo_estado = dr["TipoMuseo_estado"].ToString();
            }
            else
            {
                tipoMuseo = null;
            }
            aux.conectar();

            return tipoMuseo;
        }

    }
