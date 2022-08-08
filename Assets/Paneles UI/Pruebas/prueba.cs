using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    internal static Jugador crearJuagadorPrueba1()
    {
        return new Jugador() { NickName = "marc" };
    }

    internal static void crearJugadorPrueba()
    {
        SaveManager.Jugador = crearJuagadorPrueba1();
        SaveManager.LoadJuego();
        SaveManager.fetchPartidaStatic("oso");
        if (SaveManager.Jugador.CurrentPartida == null)
        {
            SaveManager.Jugador.CurrentPartida = new Partida()
            {
                Niveles = new List<Nivel>(new Nivel[7])
            };
        }
    }
}
