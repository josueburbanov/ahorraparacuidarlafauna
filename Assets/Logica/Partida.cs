using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Partida
{
    private Nivel currentLevel;
    private int monedasTotal;
    private string personaje;
    private DateTime fechaInicioPartida;
    private DateTime fechaUltimaVez;
    private Jugador jugadorPertenece;
    private string id;
    private List<Nivel> niveles;
    private Prestamo prestamo;

    public Nivel CurrentLevel { get => currentLevel; set => currentLevel = value; }
    public int MonedasTotal { get => monedasTotal; set => monedasTotal = value; }
    public string Personaje { get => personaje; set => personaje = value; }
    public DateTime FechaInicioPartida { get => fechaInicioPartida; set => fechaInicioPartida = value; }
    public DateTime FechaUltimaVez { get => fechaUltimaVez; set => fechaUltimaVez = value; }
    public string Id { get => id; set => id = value; }
    public List<Nivel> Niveles { get => niveles; set => niveles = value; }
    public Prestamo Prestamo { get => prestamo; set => prestamo = value; }
    public Jugador JugadorPertenece { get => jugadorPertenece; set => jugadorPertenece = value; }

    public Partida()
    {
        Niveles = new List<Nivel>();
    }

    override
    public string ToString()
    {
        string prestamoText = "";
        if(prestamo is null)
        {
            prestamoText = "nulo";
        }
        else
        {
            prestamoText = prestamo.ToString();
        }

        string primeraParte = "Partida:\n\t\t\t" +
            "Id:" + id + "\n\t\t\t" +
            "Current Level: " + currentLevel + "\n\t\t\t" +
            "Monedas Total: " + monedasTotal + "\n\t\t\t" +
            "Personaje: " + personaje + "\n\t\t\t" +
            "Fecha Inicio Partida: " + fechaInicioPartida + "\n\t\t\t" +
            "Fecha Fecha última vez: " + fechaUltimaVez + "\n\t\t\t\t\t" +
            "Préstamo: " + prestamoText + "\n\t\t\t\t\t";
        int cont = 1;
        string segundaParte = "";
        foreach (Nivel nivel in niveles)
        {
            if(nivel != null)
            {
                segundaParte = segundaParte + cont + nivel.ToString() + "\n\t\t\t\t\t";
            }
            else
            {
                segundaParte = segundaParte + cont + "Nivel null" + "\n\t\t\t\t\t";
            }
            
            cont++;
        }
        return primeraParte + segundaParte;
    }
}
