using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoIzquierda : ICommand
{
    private List<IMovible> movibles;

    public MovimientoIzquierda(List<IMovible> list)
    {
        movibles = list;
    }

    public void Execute()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.left);
        }
    }

    public void Undo()
    {
        foreach (IMovible obj in movibles)
        {
            obj.Mover(Vector3.right);
        }
    }
}
