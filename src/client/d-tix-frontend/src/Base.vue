
<script   lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'BaseComponent',

  data() {
    return {
      baseData: 'base'
    };
  },

  computed:{
    baseComputed(){
      return 'Base computed work'
    }
  },

  methods: {
    baseMethod() {
      console.log('Bu method tüm bileşenlerde kullanılabilir');
    },
  },

  created() {
    console.log('Base component created');
  },
  mounted() {
    console.log('Base component mounted');
  },
  updated() {
    console.log('Base component updated');
  },
  unmounted() {
    console.log('Base component unmounted');
  },


});
</script>
