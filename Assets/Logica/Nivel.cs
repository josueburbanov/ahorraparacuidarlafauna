using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Nivel
{
    private int numeroNivel;
    private int comida;
    private int comodinesPositivos;
    private int comodinesNegativos;
    private int vidas;
    private bool isFinished; //Solo si pasa el nivel sin préstamo o pagando préstamo.
    private bool tienePrestamo;
    private int monedas;



    public int NumeroNivel { get => numeroNivel; set => numeroNivel = value; }
    public int Comida { get => comida; set => comida = value; }
    public int ComodinesPositivos { get => comodinesPositivos; set => comodinesPositivos = value; }
    public int ComodinesNegativos { get => comodinesNegativos; set => comodinesNegativos = value; }
    public int Vidas { get => vidas; set => vidas = value; }
    public bool IsFinished { get => isFinished; set => isFinished = value; }
    public bool TienePrestamo { get => tienePrestamo; set => tienePrestamo = value; }
    public int Monedas { get => monedas; set => monedas = value; }

    public Nivel()
    {

    }

    public Nivel(int numeroNivel, int comida, int comodinesPositivos, int comodinesNegativos, int vidas, bool isFinished, bool isPaused, Prestamo prestamo, int monedas)
    {
        NumeroNivel = numeroNivel;
        Comida = comida;
        ComodinesPositivos = comodinesPositivos;
        ComodinesNegativos = comodinesNegativos;
        Vidas = vidas;
        IsFinished = isFinished;
        TienePrestamo = isPaused;
        Monedas = monedas;
    }

    public Nivel(Nivel nivelCopy)
    {
        NumeroNivel = nivelCopy.NumeroNivel;
        comida = nivelCopy.comida;
        ComodinesPositivos = nivelCopy.ComodinesPositivos;
        comodinesNegativos = nivelCopy.comodinesNegativos;
        vidas = nivelCopy.vidas;
        isFinished = nivelCopy.isFinished;
        tienePrestamo = nivelCopy.tienePrestamo;
        monedas = nivelCopy.monedas;
    }

    public Nivel(int numeroNivel, int comida, int comodinesPositivos, int comodinesNegativos, bool isFinished, Prestamo prestamo, int monedas)
    {
        NumeroNivel = numeroNivel;
        Comida = comida;
        ComodinesPositivos = comodinesPositivos;
        ComodinesNegativos = comodinesNegativos;
        IsFinished = isFinished;
        Monedas = monedas;
    }

    override
    public string ToString()
    {
        return "Nivel:\n\t\t\t\t\t" +
            "Numero nivel:" + numeroNivel + "\n\t\t\t\t\t" +
            "Comida: " + comida + "\n\t\t\t\t\t" +
            "comodinesPositivos: " + comodinesPositivos + "\n\t\t\t\t\t" +
            "comodinesNegativos: " + comodinesNegativos + "\n\t\t\t\t\t" +
            "vidas: " + vidas + "\n\t\t\t\t\t" +
            "isFinished: " + isFinished + "\n\t\t\t\t\t" +
            "Tiene Préstamo: " + tienePrestamo + "\n\t\t\t\t\t" +
            "Monedas: " + monedas;
    }
}
