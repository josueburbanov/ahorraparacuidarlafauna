using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Prestamo
{
    private int cantidadPrestada;
    private int monedasAsociadas;
    private bool pagado;
    private int nivel;

    public int CantidadPrestada { get => cantidadPrestada; set => cantidadPrestada = value; }
    public bool Pagado { get => pagado; set => pagado = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int MonedasAsociadas { get => monedasAsociadas; set => monedasAsociadas = value; }

    public Prestamo()
    {

    }

    public Prestamo(int cantidadPrestada, bool pagado, int nivel)
    {
        CantidadPrestada = cantidadPrestada;
        Pagado = pagado;
        Nivel = nivel;
    }

    public Prestamo(int cantidadPrestada, bool pagado)
    {
        CantidadPrestada = cantidadPrestada;
        Pagado = pagado;
    }

    override
    public string ToString()
    {
        return "Prestamo:\n\t\t\t\t\t\t\t" +
            "Cantidad prestada:" + cantidadPrestada + "\n\t\t\t\t\t\t\t" +
            "Pagado: " + pagado + "\n\t\t\t\t\t\t\t" +
            "Nivel: " + nivel + "\n\t\t\t\t\t\t\t";
    }

}
