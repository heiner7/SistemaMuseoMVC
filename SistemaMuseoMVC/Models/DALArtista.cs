using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class DALArtista
    {

    public Boolean insertarArtista(EntidadArtista artista)
    {

        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Artista_nacionalidad", artista.Artista_nacionalidad));
        cmd.Parameters.Add(new SqlParameter("@Artista_nombre", artista.Artista_nombre));      
        cmd.Parameters.Add(new SqlParameter("@Artista_biografia", artista.Artista_biografia));
        cmd.Parameters.Add(new SqlParameter("@Artista_estado", artista.Artista_estado));

        cmd.CommandText = "InsertarArtista";
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
    public List<EntidadArtista> listarArtista()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarArtista";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadArtista> lista = new List<EntidadArtista>();

        while (dr.Read())
        {
            EntidadArtista artista = new EntidadArtista();

            artista.Artista_id = int.Parse(dr["Artista_id"].ToString());
            artista.Artista_nombre = dr["Artista_nombre"].ToString();
            artista.Artista_nacionalidad = dr["Artista_nacionalidad"].ToString();
            artista.Artista_biografia = dr["Artista_biografia"].ToString();
            artista.Artista_estado = dr["Artista_estado"].ToString();

            lista.Add(artista);
        }
        aux.conectar();

        return lista;
    }

    public List<EntidadArtista> listarInactivo()
    {

        Conectividad aux = new Conectividad();

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = aux.conectar();
        cmd.CommandText = "ListarArtistaInactivo";

        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader dr = cmd.ExecuteReader();

        List<EntidadArtista> lista = new List<EntidadArtista>();

        while (dr.Read())
        {
            EntidadArtista artista = new EntidadArtista();

            artista.Artista_id = int.Parse(dr["Artista_id"].ToString());
            artista.Artista_nombre = dr["Artista_nombre"].ToString();
            artista.Artista_nacionalidad = dr["Artista_nacionalidad"].ToString();
            artista.Artista_biografia = dr["Artista_biografia"].ToString();
            artista.Artista_estado = dr["Artista_estado"].ToString();

            lista.Add(artista);
        }
        aux.conectar();

        return lista;
    }

    public void modificarArtista(EntidadArtista artista)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Artista_id", artista.Artista_id));
        cmd.Parameters.Add(new SqlParameter("@Artista_nacionalidad", artista.Artista_nacionalidad));
        cmd.Parameters.Add(new SqlParameter("@Artista_nombre", artista.Artista_nombre));
        cmd.Parameters.Add(new SqlParameter("@Artista_biografia", artista.Artista_biografia));
        cmd.Parameters.Add(new SqlParameter("@Artista_estado", artista.Artista_estado));

        cmd.CommandText = "ModificarArtista";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();
        aux.conectar();
    }

    public Boolean eliminarArtista(int Artista_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Artista_id", Artista_id));

        cmd.CommandText = "InactivarArtista";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }

    public Boolean activarArtista(int Artista_id)
    {
        Conectividad aux = new Conectividad();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = aux.conectar();

        cmd.Parameters.Add(new SqlParameter("@Artista_id", Artista_id));

        cmd.CommandText = "ActivarArtista";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.ExecuteNonQuery();

        int x = cmd.ExecuteNonQuery();
        aux.conectar();

        if (x >= 1)
            return true;
        else
            return false;
    }
}
