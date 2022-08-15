using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    internal static Juego crearJuegoPrueba()
    {
        Juego juego = new Juego()
        {
            Id = 0,
            Jugadores = { new Jugador() { Id = "0001", Ciudad = "Quito", Correoe = "pepe@j.com",
                NickName = "pepino", Nombre = "Josue",
                CurrentPartida = new Partida() {
                    Niveles = new List<Nivel>(new Nivel[7]),
                    Personaje = "armadillo"
                    }
                }
            }
        };
        return juego;
    }

    internal static Jugador crearJugadorPruebaInternal()
    {
        return new Jugador()
        {
            Id = "0001",
            Ciudad = "Quito",
            Correoe = "pepe@j.com",
            NickName = "pepino",
            Nombre = "Josue",
            CurrentPartida = new Partida()
            {
                Niveles = new List<Nivel>(new Nivel[7]),
                Personaje = "armadillo"

            }
        };
    }

    internal static void crearJugadorPrueba()
    {
        SaveManager.Juego = crearJuegoPrueba();
        SaveManager.Jugador = crearJugadorPruebaInternal();

    }
}
