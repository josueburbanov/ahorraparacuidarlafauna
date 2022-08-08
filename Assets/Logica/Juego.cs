using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Juego
{
    private List<Jugador> jugadores;
    private int id;

    public Juego()
    {
        id = 2;
        jugadores = new List<Jugador>();
    }


    public List<Jugador> Jugadores { get => jugadores; set => jugadores = value; }
    public int Id { get => id; set => id = value; }

    override
    public string ToString()
    {
        string primeraParte = "Juego:\n" +
            "id:" + id + "\n";
        string segundaParte = "";
        int cont = 1;
        if (jugadores != null)
            foreach (Jugador iter in jugadores)
            {
                if (iter != null)
                {
                    segundaParte = cont + iter.ToString() + "";
                }

            }
        return primeraParte + segundaParte;
    }
}
