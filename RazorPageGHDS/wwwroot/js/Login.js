window.addEventListener('load', () => {
    console.log("js session vinculado");

    // Obt�n el token de sessionStorage
    var authToken = sessionStorage.getItem("AuthToken");

    switch (true) {
        case (!authToken && token !== null && token !== undefined):
            // Si no hay un token y 'token' est� definido
            let authorizeToken = token.toString();

            // Aseg�rate de que el token a�n no se haya establecido en sessionStorage
            if (!sessionStorage.getItem("AuthToken")) {
                sessionStorage.setItem("AuthToken", authorizeToken);
                var authToken = sessionStorage.getItem("AuthToken");

                // Muestra "Cerrar Sesi�n" si el token no est� vac�o
                if (authToken && authToken.trim() !== "") {
                    mostrarCerrarSesion();
                } else {
                    mostrarIniciarSesion();
                }
            }
            break;

        case (!!authToken && authToken.trim() !== ""):
            // Si el token existe en sessionStorage y no est� vac�o, muestra "Cerrar Sesi�n"
            mostrarCerrarSesion();
            break;

        default:
            // Si el token ya existe en sessionStorage, no se recargar�
            console.log("El token ya existe en sessionStorage, no se recargar�");
            break;
    }
});

function mostrarCerrarSesion() {
    var contenido = document.getElementById('contenido');
    var botonSesion = document.getElementById('botonSesion');
    contenido.style.display = 'block';
    botonSesion.style.display = 'none';
}

function mostrarIniciarSesion() {
    var contenido = document.getElementById('contenido');
    var botonSesion = document.getElementById('botonSesion');
    contenido.style.display = 'none';
    botonSesion.style.display = 'block';
}

function cerrarSesion() {
    // L�gica para cerrar sesi�n, por ejemplo, limpiar sessionStorage y redirigir
    sessionStorage.removeItem("AuthToken");
    window.location.href = '/Index';
}

function iniciarSesion() {
    // L�gica para iniciar sesi�n, por ejemplo, redirigir a la p�gina de inicio de sesi�n
    window.location.href = '/Login';
}