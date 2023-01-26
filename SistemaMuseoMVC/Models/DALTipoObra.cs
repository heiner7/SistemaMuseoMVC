using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


    public class DALTipoObra
    {

        public Boolean insertarTipoObra(EntidadTipoObra tipoObra)
        {

            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();


            cmd.Parameters.Add(new SqlParameter("@TipoObra_id", tipoObra.TipoObra_id));
            cmd.Parameters.Add(new SqlParameter("@TipoObra_tipoObra", tipoObra.TipoObra_tipoObra));
            cmd.Parameters.Add(new SqlParameter("@TipoObra_descripcion", tipoObra.TipoObra_descripcion));
            cmd.Parameters.Add(new SqlParameter("@TipoObra_estado", tipoObra.TipoObra_estado));

            cmd.CommandText = "InsertarTipoObra";
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
        public List<EntidadTipoObra> listarTipoObra()
        {

            Conectividad aux = new Conectividad();

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = aux.conectar();
            cmd.CommandText = "ListarTipoObra";

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            List<EntidadTipoObra> lista = new List<EntidadTipoObra>();

            while (dr.Read())
            {
            EntidadTipoObra tipoObra = new EntidadTipoObra();

                tipoObra.TipoObra_id = int.Parse(dr["TipoObra_id"].ToString());
                tipoObra.TipoObra_tipoObra = dr["TipoObra_tipoObra"].ToString();
                tipoObra.TipoObra_descripcion = dr["TipoObra_descripcion"].ToString();
                tipoObra.TipoObra_estado = dr["TipoObra_estado"].ToString();

                lista.Add(tipoObra);
            }
            aux.conectar();

            return lista;
        }

    public List<EntidadTipoObra> listarInactivado()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarTipoObraInactivo";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadTipoObra> lista = new List<EntidadTipoObra>();

        while (dr.Read())
        {
            EntidadTipoObra tipoObra = new EntidadTipoObra();

            tipoObra.TipoObra_id = int.Parse(dr["TipoObra_id"].ToString());
            tipoObra.TipoObra_tipoObra = dr["TipoObra_tipoObra"].ToString();
            tipoObra.TipoObra_descripcion = dr["TipoObra_descripcion"].ToString();
            tipoObra.TipoObra_estado = dr["TipoObra_estado"].ToString();

            lista.Add(tipoObra);
        }
        aux.conectar();

        return lista;
    }

    public void modificarTipoObra(EntidadTipoObra tipoObra)
        {
            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();

            cmd.Parameters.Add(new SqlParameter("@TipoObra_id", tipoObra.TipoObra_id));
            cmd.Parameters.Add(new SqlParameter("@TipoObra_tipoObra", tipoObra.TipoObra_tipoObra));
            cmd.Parameters.Add(new SqlParameter("@TipoObra_descripcion", tipoObra.TipoObra_descripcion));
            cmd.Parameters.Add(new SqlParameter("@TipoObra_estado", tipoObra.TipoObra_estado));

            cmd.CommandText = "ModificarTipoObra";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();
            aux.conectar();
        }

        public Boolean eliminarTipoObra(int TipoObra_id)
        {
            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();

            cmd.Parameters.Add(new SqlParameter("@TipoObra_id", TipoObra_id));

            cmd.CommandText = "InactivarTipoObra";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            int x = cmd.ExecuteNonQuery();
            aux.conectar();

            if (x >= 1)
                return true;
            else
                return false;
        }

    public Boolean activarTipoObra(int TipoObra_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@TipoObra_id", TipoObra_id));

        cmd.CommandText = "ActivarTipoObra";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public EntidadTipoObra buscarTipoObra(int TipoObra_id)
        {
            EntidadTipoObra tipoObra = new EntidadTipoObra();
            Conectividad aux = new Conectividad();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = aux.conectar();

            cmd.Parameters.Add(new SqlParameter("@TipoObra_id", tipoObra.TipoObra_id));

            cmd.CommandText = "ConsultarTipoObra";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                tipoObra.TipoObra_id = int.Parse(dr["TipoObra_id"].ToString());
                tipoObra.TipoObra_tipoObra = dr["TipoObra_tipoObra"].ToString();
                tipoObra.TipoObra_descripcion = dr["TipoObra_descripcion"].ToString();
                tipoObra.TipoObra_estado = dr["TipoObra_estado"].ToString();

            }
            else
            {
                tipoObra = null;
            }
            aux.conectar();

            return tipoObra;
        }

    }
