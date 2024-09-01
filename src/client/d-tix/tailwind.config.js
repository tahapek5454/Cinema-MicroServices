module.exports = {
  purge: ['../public/index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
   darkMode: false, // or 'media' or 'class'
   theme: {
     extend: {
      fontFamily:{
        poppin: ['Poppins', 'sans-serif']
      },
      screens:{
        'bigmd': '900px'
      }
     },
     colors: {
      'blue': '#1fb6ff',
      'purple': '#7e5bef',
      'pink': '#ff49db',
      'orange': '#ff7849',
      'green': '#13ce66',
      'yellow': '#ffc82c',
      'gray-dark': '#1f1b1b',
      'gray': '#dddddd',
      'gray-light': '#d3dce6',
      'white': '#ffffff',
      'white2': '#f7f7f7',
      'dark': '#000000',
      'background': '#0C0C0D',
      'red': '#bc1a45',
      'transparent': 'transparent',
    }
   },
   variants: {
     extend: {},
   },
   plugins: [],
}