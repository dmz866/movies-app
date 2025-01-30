/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./src/**/*.{js,jsx,ts,tsx}",
    ],
    theme: {
        extend: {
            backgroundImage: {
                'movies': "url('../public/images/movies.jpg')",
            }
        },
    },
    plugins: [],
}