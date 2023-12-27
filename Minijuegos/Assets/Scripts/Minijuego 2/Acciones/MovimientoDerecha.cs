using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDerecha : ICommand
{
    private List<IMovible> movibles;

    public MovimientoDerecha(List<IMovible> list)
    {
        movibles = list;
    }

    public void Execute()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.right);
        }
    }

    public void Undo()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.left);
        }
    }
}
