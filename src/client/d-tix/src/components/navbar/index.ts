import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Navbar extends Vue {

    auido: HTMLAudioElement | null = null;
    isMusicPlay:boolean = false;

    menuExpandIconName: ExpandIcon = ExpandIcon.Menu;
    topPosition: ExpandPosition = ExpandPosition.Hide;

    items = ['Xyz Avm Sinemaları', 'Serdivan AVM Sinemaları', 'Agora Sienamalrı']
    values= ['Serdivan AVM Sinemaları']

    changeMenuExpandIcon(){
        this.menuExpandIconName === ExpandIcon.Menu 
        ? this.menuExpandIconName = ExpandIcon.Close 
        : this.menuExpandIconName = ExpandIcon.Menu
        
        this.menuExpandIconName === ExpandIcon.Menu
        ? this.topPosition = ExpandPosition.Hide
        : this.topPosition = ExpandPosition.Show;
        console.log('hello world');
    }


    created() {
        this.auido = new Audio('/a.mp3'); 
    }


    music(){
        console.log('hello world');
        const self = this;
        if(!this.auido)
            return;

        if(this.isMusicPlay){
            this.auido.pause();
            this.auido.currentTime = 0;
            this.isMusicPlay = false;
        }else{
            this.auido.play();
            this.isMusicPlay = true;

            this.auido.onended = (e)=>{
                self.$toast.success("Müzik bitti :)");
                self.isMusicPlay = false;
            }
        }        
    }
}

enum ExpandIcon{
    Menu='menu',
    Close='close'
}

enum ExpandPosition{
    Show = 'tw-top-[67px]',
    Hide = 'tw-top-[-60%] '
}