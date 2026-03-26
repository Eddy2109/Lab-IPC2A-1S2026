# Ejemplo Lista Drones

En este programa se divide el codigo en modelo vista-controlador

## Modelos:

En la carpeta *models* tenemos todas nuestras estructuras 

Clase Dron:
```Csharp
public class Dron
{
    public string Nombre { get; set;}
    public bool prendido {get; set;} //false = apagdo; true = encendido

    public int posicion { get; set; } // va a cambiar (subir o bajar)

    public int alturaMaxima { get; set; } // limite

    public Dron(string nombre, int alturaMaxima)
    {
        this.Nombre = nombre;
        this.prendido = false;
        this.alturaMaxima = alturaMaxima;
    }
}
```
Clase Nodo: 
Esta clase hereda de la clase Dron por lo tanto todos sus atributos también son heredados
```Csharp
public class Nodo : Dron
{
    public Nodo Siguiente { get; set; }

    public Nodo(string nombre, int alturaMax) : base(nombre, alturaMax)
    {
        this.Siguiente = null;
    }
}
```
Clase Lista:
```Csharp 
public class Lista
{
    public Nodo cabeza { get; set; }

    public Lista()
    {
        this.cabeza = null;
    }

    public void AgregarNodo(string nombre, int altura)
    {
        Nodo nuevoNodo = new Nodo(nombre, altura);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    public Nodo GetCabeza()
    {
        return cabeza;
    }
}
```

## Controladores

En la carpeta *controllers* tenemos el controlador de lista, aca va toda la logica del negocio es decir aca gestionaremos la lista de drones (hacerlos subir, bajar y encender)

```Csharp
public class ListaController : Controller
{
    static Lista sistemaDromes = new Lista();

    public IActionResult Index()
    {
        return View(sistemaDromes);
    }

    [HttpPost]
    public IActionResult Agregar(string nombre, int alturaMax)
    {
        sistemaDromes.AgregarNodo(nombre, alturaMax);
        return RedirectToAction("Index");
    }

    // retornar la cabeza de la lista para mostrar los drones
    public IActionResult MostrarDrones()
    {
        return View(sistemaDromes.GetCabeza());
    }
}
```

## Vistas

En la carpeta *Views* tenemos dividos por carpetas las vistas de nuestra página, en este ejemplo solo tenemos una vista para *Lista*

```cshtml
@model Clase2403.Models.Lista

<h2>Lista de Drones</h2>

<!-- en lugar de un form ustedes deben jalar los datos de los archivos XML -->

<form method="post" action="/Lista/Agregar">
    <input name="nombre" placeholder="Ingrese nombre del dron" />
    <input name="alturaMax" placeholder="Ingrese altura máxima del dron" />
    <button type="submit">Insertar</button>
</form>

<ul>
    @{
        // GetCabeza y reccorer lista
        var actual = Model.GetCabeza();
        while (actual != null)
        {
            <li>@actual.Nombre - @actual.alturaMaxima</li>
            actual = actual.Siguiente;
        }
    }
</ul>
```

En el patron MVC las vistas se comunican con los controladores que a su vez usan los modelos, los controladores ejecutan la logica del negocio (administran los drones) y luego regresan la información a las vista. 

En este ejepmlo usamos un form para ingresar un nombre para el dron y su altura maxima, luego al enviar la información por el controlador almacena la información y posteriormente obtenemos la cabeza de la lista para recorrerla y mostrar los drones agregados