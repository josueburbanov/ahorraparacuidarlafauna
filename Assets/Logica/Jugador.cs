using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Jugador
{
    [SerializeField]
    private string nombre;
    [SerializeField]
    private string nickName;
    [SerializeField]
    private string correoe;
    [SerializeField]
    private string ciudad;
    [SerializeField]
    private string id;
    [SerializeField]
    private List<Partida> partidas;
    [SerializeField]
    private Partida currentPartida;

    public string Nombre { get => nombre; set => nombre = value; }
    public string NickName { get => nickName; set => nickName = value; }
    public string Correoe { get => correoe; set => correoe = value; }
    public List<Partida> Partidas { get => partidas; set => partidas = value; }
    public Partida CurrentPartida { get => currentPartida; set => currentPartida = value; }
    public string Id { get => id; set => id = value; }
    public string Ciudad { get => ciudad; set => ciudad = value; }

    public Jugador()
    {
        partidas = new List<Partida>();
    }

    override
    public string ToString()
    {
        string primeraParte = "  Jugador:\n\t" +
            "Nombre: " + nombre + "\n\t" +
            "NickName: " + nickName + "\n\t" +
            "Correoe: " + correoe + "\n\t" +
            "Partidas: "+"\n\t" +
            "Partida actual: "+currentPartida + "\n\t" +
            "Id: " + id+"\n";
        int contPartidas = 1;
        string segundaParte = " \t\t";
        foreach (Partida partida in partidas)
        {
            segundaParte = segundaParte + contPartidas + partida + "\n\t\t\t";
            contPartidas++;
        }
        return primeraParte + segundaParte;
    }
}
