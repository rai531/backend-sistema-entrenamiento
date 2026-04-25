namespace Domain.ValueObjects;

public sealed record PeriodoTemporal
{
    public DateOnly Inicio { get; }
    public DateOnly Fin { get; }
    public int DuracionDias => Fin.DayNumber - Inicio.DayNumber;

    public PeriodoTemporal(DateOnly inicio, DateOnly fin)
    {
        if(fin < inicio)
            throw new ArgumentException(
                "La fecha de fin debe ser igual o posterior al inicio.");

        Inicio = inicio;
        Fin = fin;        
    }

    public bool SolapaConAnterior(PeriodoTemporal otro) =>
        Inicio <= otro.Fin && otro.Inicio <= Fin;
}