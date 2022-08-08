using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private Jugador jugador;
    private Partida partida;
    private Nivel nivelActual;

    public Jugador Jugador { get => jugador; set => jugador = value; }
    public Partida Partida { get => partida; set => partida = value; }
    public Nivel NivelActual { get => nivelActual; set => nivelActual = value; }


    public Main createTestPlayerForNivel1()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        NivelActual = new Nivel();
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        NivelActual.NumeroNivel = 1;
        Partida.Niveles[NivelActual.NumeroNivel - 1] = NivelActual;
        print("Creado test player");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel3PrestamoImpago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, false), 80);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 3;
        Partida.Niveles[2] = NivelActual;
        print("Creado test player 3");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel3PrestamoPago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 3;
        Partida.Niveles[2] = NivelActual;
        print("Creado test player 3");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel4PrestamoImpago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(20, false), 60);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 4;
        Partida.Niveles[3] = NivelActual;
        print("Creado test player 4");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel4PrestamoPago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(30, true), 80);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 4;
        Partida.Niveles[3] = NivelActual;
        print("Creado test player 4");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel5PrestamoImpago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(20, true), 60);
        Partida.Niveles[3] = new Nivel(4, 80, 10, 11, true, new Prestamo(20, false), 60);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 5;
        Partida.Niveles[4] = NivelActual;
        print("Creado test player 5");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel5PrestamoPago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[3] = new Nivel(4, 80, 10, 11, true, new Prestamo(30, true), 70);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 5;
        Partida.Niveles[4] = NivelActual;
        print("Creado test player 5");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel6PrestamoPago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[3] = new Nivel(4, 80, 10, 11, true, new Prestamo(30, true), 70);
        Partida.Niveles[4] = new Nivel(5, 80, 10, 11, true, new Prestamo(30, true), 70);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 6;
        Partida.Niveles[5] = NivelActual;
        print("Creado test player 6");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel6PrestamoImpago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(20, true), 60);
        Partida.Niveles[3] = new Nivel(4, 80, 10, 11, true, new Prestamo(20, true), 60);
        Partida.Niveles[4] = new Nivel(5, 80, 10, 11, true, new Prestamo(20, false), 60);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 6;
        Partida.Niveles[5] = NivelActual;
        print("Creado test player 6");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel7PrestamoImpago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(20, true), 60);
        Partida.Niveles[3] = new Nivel(4, 80, 10, 11, true, new Prestamo(20, true), 60);
        Partida.Niveles[4] = new Nivel(5, 80, 10, 11, true, new Prestamo(20, true), 60);
        Partida.Niveles[5] = new Nivel(6, 80, 10, 11, true, new Prestamo(20, false), 60);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 7;
        Partida.Niveles[6] = NivelActual;
        print("Creado test player 7");
        print(this);
        return this;
    }

    public Main createTestPlayerForNivel7PrestamoPago()
    {
        Jugador = new Jugador();
        Jugador.NickName = "Josue";
        Partida = new Partida();
        Partida.Personaje = "Armadillo";
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        Partida.Niveles = new List<Nivel>(new Nivel[10]);
        Partida.Niveles[0] = new Nivel(1, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[1] = new Nivel(2, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[2] = new Nivel(3, 80, 10, 11, true, new Prestamo(30, true), 80);
        Partida.Niveles[3] = new Nivel(4, 80, 10, 11, true, new Prestamo(30, true), 70);
        Partida.Niveles[4] = new Nivel(5, 80, 10, 11, true, new Prestamo(30, true), 70);
        Partida.Niveles[5] = new Nivel(6, 80, 10, 11, true, new Prestamo(30, true), 70);
        NivelActual = new Nivel();
        NivelActual.NumeroNivel = 7;
        Partida.Niveles[6] = NivelActual;
        print("Creado test player 7");
        print(this);
        return this;
    }


    public void pagarPrestamo()
    {
        print("Pagando prestamo start..............................");
        print(NivelActual.NumeroNivel);
        print(Partida.Niveles[NivelActual.NumeroNivel - 2]);
        //print(Partida.Niveles[NivelActual.NumeroNivel - 2].Prestamo.Pagado);
        //Partida.Niveles[NivelActual.NumeroNivel - 2].Prestamo.Pagado = true;
        print("Pagando presstamo end..............................");
    }

    public void checkInfoJugador()
    {

    }
    public void crearJugador()
    {
        TextMeshProUGUI TextNick = GameObject.Find("TextNick").GetComponent<TextMeshProUGUI>();
        Jugador = new Jugador();
        Jugador.NickName = TextNick.text;
        if (jugador.NickName == "Jose") //Check nick
        {
            print("Nick duplicado");
        }

        print(TextNick.text);
        print("Jugador creado..." + Jugador);
    }

    public void crearPartida()
    {
        Partida = new Partida();
        Jugador.Partidas.Add(Partida);
        Partida.Id = "0001";
        print("Partida creada..." + Partida);
        Partida.Niveles = new List<Nivel>(new Nivel[7]);
    }

    public void seleccionarCaracter(string personaje)
    {
        Partida.Personaje = personaje;
    }

    public void crearNivel(int nivel)
    {
        bool posibleCreate = false;
        if (NivelActual is null)
        {
            posibleCreate = true;
        }
        else if (NivelActual.NumeroNivel != nivel)
        {
            posibleCreate = true;
        }
        if (posibleCreate)
        {
            NivelActual = new Nivel();
            NivelActual.NumeroNivel = nivel;
            if (existeNivel(nivel))
            {
                sobreEscribirNivel(nivel, NivelActual);
            }
            else
            {
                Partida.Niveles[nivel - 1] = NivelActual;
            }

            print("Nivel creado..." + Partida);
            print("Nivel agregado..." + Partida);
            print(checkNumerodeNivelesAux());
        }
    }

    public void sobreEscribirNivel(int nivel, Nivel nuevoNivel)
    {
        Nivel nivelAntiguo;
        if (!(partida.Niveles is null))
            foreach (var item in Partida.Niveles)
            {
                if (nivel == item.NumeroNivel)
                {
                    nivelAntiguo = nuevoNivel;
                    break;
                }
            }
    }

    public bool existeNivel(int nivel)
    {
        if (!(partida.Niveles is null))
            foreach (var item in Partida.Niveles)
            {
                if (!(item is null))
                {
                    if (nivel == item.NumeroNivel)
                    {
                        return true;
                    }
                }
            }
        return false;
    }

    //Guardar nivel superado sin prestamo
    public void terminarNivelSinPrestamo()
    {
        Nivel nivelTerminado = new Nivel(NivelActual);
        nivelTerminado.IsFinished = true;
        Partida.Niveles[NivelActual.NumeroNivel - 1] = nivelTerminado;
        print("nivel terminado");
        print(checkNumerodeNivelesAux());
        NivelActual = null;
    }

    //Guardar nivel superado con prestamo
    public void terminarNivel()
    {
        Nivel nivelTerminado = new Nivel(NivelActual);
        Partida.Niveles[NivelActual.NumeroNivel - 1] = nivelTerminado;
        print("nivel terminado");
        print(checkNumerodeNivelesAux());
        NivelActual = null;
    }

    //Terminar nivel por termino de vidas
    public void terminarNivelXTerminoVidas()
    {
        //partida.Niveles.RemoveAt(NivelActual.NumeroNivel - 1);
        partida.Niveles[NivelActual.NumeroNivel - 1] = null;
        print(checkNumerodeNivelesAux());
        NivelActual = null;
    }

    public void hacerPrestamo(int cantidad)
    {
        //if (NivelActual.Prestamo is null)
        //{
        //    Prestamo prestamoNew = new Prestamo();
        //    prestamoNew.CantidadPrestada = cantidad;
        //    prestamoNew.Pagado = false;
        //    NivelActual.Prestamo = prestamoNew;
        //    print("prestamo realizado" + NivelActual.Prestamo.CantidadPrestada);
        //}
    }

    //Encera los contadores de nivel y préstamos a 0?
    public void prepararNivelReiniciar()
    {
        Nivel nivelReiniciar = new Nivel();
        nivelReiniciar.NumeroNivel = NivelActual.NumeroNivel;
        if (!Partida.Niveles[NivelActual.NumeroNivel - 1].IsFinished)
        {
            Partida.Niveles[NivelActual.NumeroNivel - 1] = nivelReiniciar;
        }
        print(checkNumerodeNivelesAux());
        NivelActual = null;
    }

    //solo para debug
    private string checkNumerodeNivelesAux()
    {
        if (partida.Niveles == null)
        {
            return "Numero de niveles actual es: nada ";
        }
        else
        {
            int cont = 0;
            foreach (var item in Partida.Niveles)
            {
                if (!(item is null))
                {
                    cont++;

                }
            }
            return "Numero de niveles actual es : " + cont;
        }
    }

    public void anotarAlimento(int cantidadAlimento)
    {
        NivelActual.Comida = cantidadAlimento;
        print("anotado" + cantidadAlimento);
    }

    public void anotarComodinesPositivos(int comodines)
    {
        NivelActual.ComodinesPositivos = comodines;
        print("anotadoComodines " + comodines);
    }

    public void anotarComodinesNegativos(int comodines)
    {
        NivelActual.ComodinesNegativos = comodines;
        print("anotadoComodinesNegga " + comodines);
    }

    public void anotarMonedas(int monedas)
    {
        NivelActual.Monedas = monedas;
        print("anotado monedas " + monedas);
    }

    public bool tienePrestamosImpagos()
    {
        foreach (Nivel iterNivel in Partida.Niveles)
        {
            //if (!(iterNivel is null))
            //{
            //    if (iterNivel.Prestamo is null)
            //    {
            //        continue;
            //    }
            //    if (!iterNivel.Prestamo.Pagado)
            //    {
            //        return true;
            //    }
            //}
        }
        return false;
    }

    public Nivel nivelAnterior(int currentLevel)
    {
        return Partida.Niveles[currentLevel - 2];
    }

    //public int getValorPrestamoAnterior(int currentLevel)
    //{
    //    Nivel nivelAnt = nivelAnterior(currentLevel);
    //    if (nivelAnt.Prestamo is null)
    //    {
    //        return 0;
    //    }
    //    else if (nivelAnt.Prestamo.CantidadPrestada != 0 && !nivelAnt.Prestamo.Pagado)
    //    {
    //        return nivelAnt.Prestamo.CantidadPrestada;
    //    }
    //    else
    //    {
    //        return 0;
    //    }
    //}

    public int getMonedasOverall()
    {
        int monedasOverall = 0;
        foreach (Nivel iterNivel in Partida.Niveles)
        {
            if (!(iterNivel is null))
            {
                monedasOverall = monedasOverall + iterNivel.Monedas;
            }
        }
        return monedasOverall;
    }

    public int getLastFinishedLevel()
    {
        int lastLevel = 0;
        foreach (var itemNivel in Partida.Niveles)
        {
            if (!(itemNivel is null))
            {
                if (itemNivel.IsFinished)
                {
                    lastLevel = itemNivel.NumeroNivel;
                }
            }
        }
        print("last level finished is " + lastLevel);
        return lastLevel;
    }

    override
    public string ToString()
    {
        if (partida is null)
        {
            return "Jugador " + jugador.NickName + " | Partida = null | " + checkNumerodeNivelesAux()
            + " | Nivel actual" + NivelActual.NumeroNivel;
        }
        else if (jugador is null)
        {
            return "Jugador = " + Jugador.NickName + " | Partida " + partida.Personaje + checkNumerodeNivelesAux()
            + " | Nivel actual" + NivelActual.NumeroNivel;
        }
        else if (partida.Niveles is null)
        {
            return "Jugador = " + Jugador.NickName + " |Partida " + partida.Personaje + checkNumerodeNivelesAux() + " | Nivel actual" + NivelActual.NumeroNivel;
        }
        else if (nivelActual is null)
        {
            return "Jugador = " + Jugador.NickName + " | Partida " + partida.Personaje + checkNumerodeNivelesAux()
            + " | Nivel actual = null";
        }
        else
        {
            return "Jugador " + jugador.NickName + " | Partida " + partida.Personaje + checkNumerodeNivelesAux()
            + " | Nivel actual" + NivelActual.NumeroNivel;
        }



    }
}
