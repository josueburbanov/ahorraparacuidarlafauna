﻿using System;
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
                NickName = "jugador_prueba", Nombre = "Josue",
                CurrentPartida = new Partida() {
                    Niveles = new List<Nivel>(new Nivel[7]),
                    Personaje = "oso"
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
            NickName = "jugador_prueba",
            Nombre = "Josue",
            CurrentPartida = new Partida()
            {
                Niveles = new List<Nivel>(new Nivel[7]),
                Personaje = "oso"

            }
        };
    }

    internal static void crearJugadorPrueba()
    {
        SaveManager.Juego = crearJuegoPrueba();
        SaveManager.Jugador = crearJugadorPruebaInternal();

    }
}
