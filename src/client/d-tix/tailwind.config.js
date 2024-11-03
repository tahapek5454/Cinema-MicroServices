module.exports = {
  purge: ['../public/index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  prefix: 'tw-',
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {
    fontFamily:{
      poppin: ['Poppins', 'sans-serif']
    },
    screens:{
      'bigmd': '900px'
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
      'background': '#121212',
      'component-color': 'rgba(255, 255, 255, 0.05)',
      'component-border': 'rgba(255, 255, 255, 0.1)',
      'component-gray': '#3D4245',
      'red': '#bc1a45',
      'transparent': 'transparent',
      'krem':'#f6e3ba',
      'koyukrem': '#dfcaa0'
    },
    spacing:{
      '128': '32rem'
    }
    }
  },
  variants: {
    extend: {},
  },
  plugins: [],
}