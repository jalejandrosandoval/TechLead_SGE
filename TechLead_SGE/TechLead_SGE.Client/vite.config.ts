import { fileURLToPath, URL } from 'node:url';
import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react';
import { env } from 'process';

// Establece el target de la API como HTTP en localhost
const target = 'http://localhost:5043';

// Configuración de Vite
export default defineConfig({
    plugins: [plugin()],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        port: parseInt(env.DEV_SERVER_PORT || '50608'),
        proxy: {
            '^/swagger': {
                target,
                secure: false,
                changeOrigin: true
            }
        }
    }
})