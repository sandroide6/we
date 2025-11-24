window.authFunctions = {
    getAntiforgeryToken: function() {
        const tokenElement = document.querySelector('input[name="__RequestVerificationToken"]');
        return tokenElement ? tokenElement.value : '';
    },
    
    login: async function (email, password) {
        try {
            const token = this.getAntiforgeryToken();
            const response = await fetch('/api/auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': token
                },
                body: JSON.stringify({ email, contraseña: password }),
                credentials: 'include'
            });
            const data = await response.json();
            return data;
        } catch (error) {
            return { success: false, message: 'Error de conexión' };
        }
    },
    register: async function (email, nombre, apellido, password, passwordConfirm) {
        try {
            const token = this.getAntiforgeryToken();
            const response = await fetch('/api/auth/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': token
                },
                body: JSON.stringify({
                    email,
                    nombre,
                    apellido,
                    contraseña: password,
                    contraseñaConfirm: passwordConfirm
                }),
                credentials: 'include'
            });
            const data = await response.json();
            return data;
        } catch (error) {
            return { success: false, message: 'Error de conexión' };
        }
    },
    logout: async function () {
        try {
            const token = this.getAntiforgeryToken();
            await fetch('/api/auth/logout', {
                method: 'POST',
                headers: {
                    'RequestVerificationToken': token
                },
                credentials: 'include'
            });
            return { success: true };
        } catch (error) {
            return { success: false };
        }
    }
};
