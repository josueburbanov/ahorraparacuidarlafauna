using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class SaveManager : MonoBehaviour
{
    private static Juego juego;
    private static Jugador jugador;

    public static Juego Juego { get => juego; set => juego = value; }
    public static Jugador Jugador { get => jugador; set => jugador = value; }

    private void Start()
    {
        if (Juego == null)
        {
            LoadJuego();
        }
    }

    public void crearJugador()
    {
        TextMeshProUGUI TextNick = GameObject.Find("TextNick").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI TextCorreo = GameObject.Find("TextCorreo").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI TextNombre = GameObject.Find("TextNombre").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI TextCiudad = GameObject.Find("TextCiudad").GetComponent<TextMeshProUGUI>();

        if (findPlayerByNick(TextNick.text) is null) //Check nick
        {
            Jugador newJugador = new Jugador();
            newJugador.NickName = TextNick.text.Trim();
            newJugador.Correoe = TextCorreo.text.Trim();
            newJugador.Ciudad = TextCiudad.text.Trim();
            newJugador.Nombre = TextNombre.text.Trim();
            string idRand = UnityEngine.Random.Range(10001, 20000).ToString();
            while (checkIdJugador(idRand))
            {
                idRand = UnityEngine.Random.Range(10001, 20000).ToString();
            }
            newJugador.Id = idRand;
            Jugador = newJugador;
            Juego.Jugadores.Add(Jugador);
            Debug.LogAssertion("Jugador nuevo creado..." + Jugador.NickName);
        }
        else
        {
            Jugador = findPlayerByNick(TextNick.text);
            Debug.LogAssertion("Jugador antiguo cargado..." + Jugador.NickName);
        }
    }

    private bool checkIdJugador(string idGenerado)
    {
        if (Juego.Jugadores.Find(x => x.Id.Equals(idGenerado)) is null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public void fetchPartida(string personaje)
    {
        if (Jugador.Partidas is null || Jugador.Partidas.Count == 0)
        {
            crearNuevaPartida(personaje);
        }
        else if (buscarPartidaPorPersonaje(personaje) is null)
        {
            crearNuevaPartida(personaje);
        }
        else
        {
            Jugador.CurrentPartida = buscarPartidaPorPersonaje(personaje);
        }
    }

    //Solo pruebas
    public static void fetchPartidaStatic(string personaje)
    {
        
        Jugador.CurrentPartida = buscarPartidaPorPersonajeStatic(personaje);
    }
    public void crearNuevaPartida(string personaje)
    {
        Partida partida = new Partida();
        Jugador.Partidas.Add(partida);
        partida.Id = UnityEngine.Random.Range(10000, 20000).ToString();
        Debug.LogAssertion("Partida creada..." + partida.Id);
        partida.Niveles = new List<Nivel>(new Nivel[7]);
        Debug.LogAssertion("Niveles creados: " + partida.Niveles.Count);
        foreach (var nivel in partida.Niveles)
        {
            print(nivel);
        }
        Jugador.CurrentPartida = partida;
        Jugador.CurrentPartida.Personaje = personaje;
    }

    public Partida buscarPartidaPorPersonaje(string personaje)
    {
        return Jugador.Partidas.Find(x => x.Personaje.Equals(personaje));
    }

    //Solo pruebas
    public static Partida buscarPartidaPorPersonajeStatic(string personaje)
    {
        foreach (var item in jugador.Partidas)
        {
            print("Personaje "+item.Personaje+" Length "+item.Personaje.Length);
        }
        print("Partida encontrada " + Jugador.Partidas.Find(x => x.Personaje.Equals(personaje)));
        return Jugador.Partidas.Find(x => x.Personaje.Equals(personaje));
    }

    internal static string getPersonaje()
    {
        return Jugador.CurrentPartida.Personaje;
    }

    internal static string getNickActual()
    {
        return Jugador.NickName;
    }

    public int getLastFinishedLevel()
    {
        int lastLevel = 0;
        foreach (Nivel itemNivel in Jugador.CurrentPartida.Niveles)
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

    /// <summary>
    /// Crea un nivel temporal
    /// </summary>
    /// <param name="nivel"></param>
    public void crearNivel(int nivel)
    {
        Nivel nivelTemp = new Nivel();
        nivelTemp.NumeroNivel = nivel;
        Jugador.CurrentPartida.CurrentLevel = nivelTemp;
    }

    public bool tienePrestamosImpagos()
    {
        //Check en los niveles guardados
        int indexJugadorActual = Juego.Jugadores.FindIndex(x => x.Id.Equals(Jugador.Id));
        if (indexJugadorActual != -1)
        {
            print("Prestamo status "+(Jugador.CurrentPartida.Prestamo == null));
            if (Jugador.CurrentPartida.Prestamo == null) return false;
            else return true;
        }
        return false;
    }

    public void pagarPrestamo()
    {
        print("---entra pagar prestamo");
        if (jugador.CurrentPartida.Prestamo != null )
        {
            print("--paga prestamo");
            Jugador.CurrentPartida.Prestamo = null;
        }
        print("---fin pagar prestamo");

    }

    public bool tienePrestamoActual()
    {
        if (jugador.CurrentPartida.Prestamo is null)
            return false;
        else
        {
            return jugador.CurrentPartida.Prestamo.Pagado;
        }

    }

    public int getMonedasOverall()
    {
        return jugador.CurrentPartida.MonedasTotal;
    }
    public int getValorPrestamoAnterior()
    {
        int valorAPagar = 0;
        int indexJugadorActual = Juego.Jugadores.FindIndex(x => x.Id.Equals(Jugador.Id));
        if (indexJugadorActual != -1)
        {
            if (Juego.Jugadores[indexJugadorActual].CurrentPartida.Prestamo != null)
                return Juego.Jugadores[indexJugadorActual].CurrentPartida.Prestamo.CantidadPrestada;
            else if (Jugador.CurrentPartida.Prestamo != null)
                return Jugador.CurrentPartida.Prestamo.CantidadPrestada;
        }
        return valorAPagar;
    }

    public Prestamo getPrestamoAnterior()
    {
        int indexJugadorActual = Juego.Jugadores.FindIndex(x => x.Id.Equals(Jugador.Id));
        if (indexJugadorActual != -1)
        {
            if (Juego.Jugadores[indexJugadorActual].CurrentPartida.Prestamo != null)
                return Juego.Jugadores[indexJugadorActual].CurrentPartida.Prestamo;
            else if (Jugador.CurrentPartida.Prestamo != null)
                return Jugador.CurrentPartida.Prestamo;
        }
        return null;
    }
    public int getValorMonedasPrestamo()
    {
        int valorAPagar = 0;
        int indexJugadorActual = Juego.Jugadores.FindIndex(x => x.Id.Equals(Jugador.Id));
        if (indexJugadorActual != -1)
        {
            if (Juego.Jugadores[indexJugadorActual].CurrentPartida.Prestamo != null)
                return Juego.Jugadores[indexJugadorActual].CurrentPartida.Prestamo.MonedasAsociadas;
            else if (Jugador.CurrentPartida.Prestamo != null)
                return Jugador.CurrentPartida.Prestamo.MonedasAsociadas;
        }
        return valorAPagar;
    }
    public int getBest(int nivel)
    {
        if (Jugador.CurrentPartida.Niveles is null || Jugador.CurrentPartida.Niveles.Count == 0)
        {
            return 0;
        }
        else if (Jugador.CurrentPartida.Niveles[nivel - 1] == null)
        {
            return 0;
        }
        else if (getJugadorGuardado().CurrentPartida.Niveles[nivel - 1] == null)
        {
            return 0;
        }
        else if (getJugadorGuardado().CurrentPartida.Niveles[nivel - 1] != null)
        {
            return getJugadorGuardado().CurrentPartida.Niveles[nivel - 1].Monedas;
        }
        return Jugador.CurrentPartida.Niveles[nivel - 1].Monedas;
    }

    public void hacerPrestamo(int cantidad, int monedasAsociadas, int nivel)
    {
        if (Jugador.CurrentPartida.Prestamo is null)
        {
            Prestamo prestamoNew = new Prestamo();
            prestamoNew.CantidadPrestada = cantidad;
            prestamoNew.MonedasAsociadas = monedasAsociadas;
            prestamoNew.Nivel = nivel;
            print("monedas asociadas " + prestamoNew.MonedasAsociadas);
            prestamoNew.Pagado = false;
            Jugador.CurrentPartida.Prestamo = prestamoNew;
            Jugador.CurrentPartida.CurrentLevel.TienePrestamo = true;
        }
    }

    public void agregarMonedasAsociadasPrestamo(int monedasAsociadas)
    {
        Jugador.CurrentPartida.Prestamo.MonedasAsociadas = monedasAsociadas;
    }
    public void anotarStats(int cantidadAlimento, int comodinesPos, int comodinesNeg, int monedas)
    {
        Jugador.CurrentPartida.CurrentLevel.Comida = cantidadAlimento;
        Jugador.CurrentPartida.CurrentLevel.ComodinesPositivos = comodinesPos;
        Jugador.CurrentPartida.CurrentLevel.ComodinesNegativos = comodinesNeg;
        Jugador.CurrentPartida.CurrentLevel.Monedas = monedas;
    }

    public void terminarNivelConPrestamo()
    {
        Nivel nivelTerminado = new Nivel(Jugador.CurrentPartida.CurrentLevel);
        nivelTerminado.IsFinished = false;
        Jugador.CurrentPartida.MonedasTotal += Jugador.CurrentPartida.CurrentLevel.Monedas;
        if (Jugador.CurrentPartida.Niveles[Jugador.CurrentPartida.CurrentLevel.NumeroNivel - 1] == null)
        {
            Jugador.CurrentPartida.Niveles[Jugador.CurrentPartida.CurrentLevel.NumeroNivel - 1] = nivelTerminado;
        }
        Jugador.CurrentPartida.CurrentLevel = null;
        guardarPartida();
    }

    public void quitarMonedasXNoPago(int monedasPrestamo)
    {
        Jugador.CurrentPartida.MonedasTotal -= monedasPrestamo;
        if(Jugador.CurrentPartida.MonedasTotal < 0)
        {
            Jugador.CurrentPartida.MonedasTotal = 0;
        }
    }

    public void anotarSiRecord(Nivel nivelTerminado)
    {
        if (Jugador.CurrentPartida.Niveles[Jugador.CurrentPartida.CurrentLevel.NumeroNivel - 1] != null)
        {
            if (Jugador.CurrentPartida.Niveles[Jugador.CurrentPartida.CurrentLevel.NumeroNivel - 1].Monedas <
            Jugador.CurrentPartida.CurrentLevel.Monedas)
            {
                Jugador.CurrentPartida.Niveles[Jugador.CurrentPartida.CurrentLevel.NumeroNivel - 1] = nivelTerminado;
            }
        }
        else
        {
            Jugador.CurrentPartida.Niveles[Jugador.CurrentPartida.CurrentLevel.NumeroNivel - 1] = nivelTerminado;
        }
    }

    public void terminarNivelSinPrestamo()
    {
        Nivel nivelTerminado = new Nivel(Jugador.CurrentPartida.CurrentLevel);
        nivelTerminado.IsFinished = true;
        anotarSiRecord(nivelTerminado);
        Jugador.CurrentPartida.MonedasTotal += Jugador.CurrentPartida.CurrentLevel.Monedas;
        Jugador.CurrentPartida.CurrentLevel = null;
        guardarPartida();
    }
    public void guardarPartida()
    {
        Partida partidaGuardar = buscarPartidaPorPersonaje(getPersonaje());
        partidaGuardar = Jugador.CurrentPartida;
    }

    //Dejamos el nivel como estaba antes, si había.
    public void terminarNivelIncompleto()
    {
        print(getJugadorGuardado());
        Jugador = getJugadorGuardado();
    }

    private static Jugador getJugadorGuardado()
    {
        int indexCurrentPlayer = Juego.Jugadores.FindIndex(x => x.Id.Equals(Jugador.Id));
        if (indexCurrentPlayer != -1)
            return Juego.Jugadores[indexCurrentPlayer];
        return null;
    }

    public static void SaveJugadorActual()
    {
        int indexCurrentPlayer;
        if (juego.Jugadores.Count != 0)
        {
            indexCurrentPlayer = Juego.Jugadores.FindIndex(x => x.Id.Equals(Jugador.Id));
            if (indexCurrentPlayer != -1)
                Juego.Jugadores[indexCurrentPlayer] = Jugador;
        }
    }

    public static void SaveJuego()
    {
        if (!(Juego is null))
        {
            SaveJugadorActual();
            IOSystem.SaveJuego(Juego);
            Debug.LogAssertion("Juego guardado" + Juego.ToString());
        }
    }

    public static void LoadJugadorActual()
    {
        if (findPlayerByNick(Jugador.NickName) is null)
        {
            Debug.LogError("No hay tal jugador con ese nick");
        }
        else
        {
            Jugador = findPlayerByNick(Jugador.NickName);
            Debug.LogAssertion("Jugador Cargado " + Jugador.NickName);
        }
    }


    public static void LoadJuego()
    {
        Juego = IOSystem.LoadJuego();
        if (Juego is null)
        {
            Juego = new Juego();
            SaveJuego();
            print("First time");
        }
        else
        {
            if (Jugador != null)
            {
                LoadJugadorActual();
            }
            Debug.LogAssertion("Juego cargado" + Juego.ToString());
            string jugadoresDebug = "Los jugadores son: \n";
            foreach (var au in Juego.Jugadores)
            {
                jugadoresDebug += au;
            }
            print(jugadoresDebug);
        }

    }
    public static Jugador findPlayerByNick(string nick)
    {
        Jugador aux = Juego.Jugadores.Find(x => string.Equals(x.NickName.Replace("\u200B", ""), nick));
        if (aux == null)
        {
            aux = Juego.Jugadores.Find(x => string.Equals(x.NickName, nick));
        }
        return aux;
    }



    public static Partida findPartidaById(string idPartida)
    {
        return Jugador.Partidas.Find(x => x.Id.Equals(idPartida));
    }
    
    public static int findJugadorIndexById(string id)
    {
        for (int i = 0; i < Juego.Jugadores.Count; i++)
        {
            if (Juego.Jugadores[i].Id == id)
            {
                return i;
            }
        }
        return -1;
    }

    public static void removeJugadorById()
    {
        Juego.Jugadores.RemoveAt(findJugadorIndexById(Jugador.Id));
    }
}
