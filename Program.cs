using Spectre.Console;

decimal monto = AnsiConsole.Ask<decimal> ("Ingrese el monto del prestamo: ");
decimal tasaInteres = AnsiConsole.Ask<decimal> ("Ingrese tasa de interes: ");
int plazo = AnsiConsole.Ask<int> ("Ingrese su plazo: ");

var tabla = new Table();

tabla.Border(TableBorder.Rounded);
tabla.AddColumn(new TableColumn("[bold cyan]No. de cuota[/]").Centered());
tabla.AddColumn(new TableColumn("[bold green]Pago de cuota[/]").RightAligned());
tabla.AddColumn(new TableColumn("[bold red]Interés a pagar[/]").RightAligned());
tabla.AddColumn(new TableColumn("[bold blue]Abono a capital[/]").RightAligned());
tabla.AddColumn(new TableColumn("[bold yellow]Saldo[/]").RightAligned());

decimal tasaInteresMensual = tasaInteres /12/100;

decimal numerador = (decimal)Math.Pow(1+(double)tasaInteresMensual,plazo);
decimal denominador = (decimal)Math.Pow(1+(double)tasaInteresMensual,plazo)-1;

decimal cuotaFija = monto * tasaInteresMensual * (numerador/denominador);

decimal saldo = monto;

for (int i = 1; i <= plazo; i++)
{
    decimal interes = saldo * tasaInteresMensual;
    decimal abonoCapital = cuotaFija - interes;
    saldo -= abonoCapital;

    tabla.AddRow(
        i.ToString(),
        cuotaFija.ToString("N2"),
        interes.ToString("N2"),
        abonoCapital.ToString("N2"),
        saldo.ToString("N2")
    );

}
AnsiConsole.Write(tabla);
