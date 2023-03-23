using System.Collections.Generic;
int menu;
bool condicion;
condicion = true;
Dictionary<string,int> dicCursos = new Dictionary<string,int>();
do{
    menu = ingresarInt("Ingrese La opcion: 1.Ingrese los importes de un curso    2. Ver estadisticas    otro número. Terminar");
    switch (menu){
        case 1: 
            solicitarCurso();
            break;
        case 2:
            if (dicCursos.Count > 0) verEstadisticas();
            else Console.WriteLine("Error. Aún no hay estadísticas");
            break;
        default:
            break;
    }
    
}while(menu == 1 || menu == 2);

void solicitarCurso(){
    string nombreCurso;
   int cantAlumnos;
   int acumAlumno = 0;
    nombreCurso = ingresarString("Ingrese el nombre del curso, o 'fin' para finalizar el ingreso.");
    nombreCurso = validarNombreCurso(nombreCurso);
    while (nombreCurso.ToLower() != "fin") {
        acumAlumno = ingresarDineroDelCurso();
        dicCursos.Add(nombreCurso,acumAlumno);
        acumAlumno = 0;
        nombreCurso = ingresarString("Ingrese el nombre del curso, o 'fin' para finalizar el ingreso.");
        nombreCurso = validarNombreCurso(nombreCurso);
    }
}

int ingresarInt(string texto) {
    int devolver = -1;
    bool valid;
    Console.WriteLine(texto);
    do {
        valid = int.TryParse(Console.ReadLine(), out devolver);
        if (devolver <= 0 || !valid) {
            Console.WriteLine("error. ingrese nuevamente");
    }
    } while (devolver <= 0 || !valid);
    return devolver;
}

string ingresarString(string mensaje) {
    string devolver;
    Console.WriteLine(mensaje);
    do {
        devolver = Console.ReadLine();
    if (devolver.Length == 0 ) {
        Console.WriteLine("Error. Ingrese de nuevo");
    }
    } while (devolver.Length == 0);
    return devolver;
}

void verEstadisticas() {
    int cursoQueMasPuso = 0;
    string nombreCursoQueMAsPuso = "";
    int acumPlataTodos = 0;
    
foreach (string clave in dicCursos.Keys)
{
    cursoQueMasPuso = numMayor(cursoQueMasPuso, dicCursos[clave]);
    if (cursoQueMasPuso == dicCursos[clave]) nombreCursoQueMAsPuso = clave;
    acumPlataTodos += dicCursos[clave];
}

Console.WriteLine("El curso que más plata puso es " + nombreCursoQueMAsPuso + ", que puso $" + cursoQueMasPuso);
Console.WriteLine("El promedio de plata de todos los cursos es $" + acumPlataTodos / dicCursos.Count);
Console.WriteLine("La recaudación total de todos los cursos es de $" + acumPlataTodos);
Console.WriteLine("La cantidad de cursos que participan del regalo es/son " + dicCursos.Count);
}

int numMayor(int num1, int num2) {
    if (num1 < num2) return num2;
    else return num1;
}

string validarNombreCurso(string nombreCurso) {
    if (dicCursos.ContainsKey(nombreCurso)) {
        do {
            nombreCurso = ingresarString("Ese curso ya existe. Ingrese otro");
        } while (dicCursos.ContainsKey(nombreCurso));
       
    }
     return nombreCurso;
}

int ingresarDineroDelCurso() {
    int acumAlumnos = 0;
int cantAlumnos = ingresarInt("Ingrese la cantidad de alumnos de ese curso");
        for (int i = 1; i <= cantAlumnos; i++)
        {
          acumAlumnos += ingresarInt("ingrese la cantidad de plata que pondrá el alumno N°" + i);
        }
    return acumAlumnos;
}