using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public List<ICommand> comandosEjecutados = new List<ICommand>();
    private int ultimoComandoEjecutado = 0;

    public void EjecutarComando(ICommand comando)
    {
        comando.Execute();
        comandosEjecutados.Add(comando);
        ultimoComandoEjecutado = comandosEjecutados.Count - 1;
    }

    public void DeshacerComando()
    {
        if(ultimoComandoEjecutado >= 0)
        {
            ICommand ultimoComando = comandosEjecutados[ultimoComandoEjecutado];
            ultimoComando.Undo();
            comandosEjecutados.Remove(ultimoComando);
            ultimoComandoEjecutado = comandosEjecutados.Count - 1;
        }
    }

    public void RehacerComando()
    {
        ICommand ultimoComando = comandosEjecutados[ultimoComandoEjecutado];
        ultimoComando.Execute();
        comandosEjecutados.Add(ultimoComando);
        ultimoComandoEjecutado = comandosEjecutados.Count - 1;
    }
}
