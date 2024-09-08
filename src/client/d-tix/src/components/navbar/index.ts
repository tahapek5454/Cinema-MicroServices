import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Navbar extends Vue {

    menuExpandIconName: ExpandIcon = ExpandIcon.Menu;
    topPosition: ExpandPosition = ExpandPosition.Hide;

    changeMenuExpandIcon(){
        this.menuExpandIconName === ExpandIcon.Menu 
        ? this.menuExpandIconName = ExpandIcon.Close 
        : this.menuExpandIconName = ExpandIcon.Menu
        
        this.menuExpandIconName === ExpandIcon.Menu
        ? this.topPosition = ExpandPosition.Hide
        : this.topPosition = ExpandPosition.Show;
    }

    items = ['Xyz Avm Sinemaları', 'Serdivan AVM Sinemaları', 'Agora Sienamalrı']
    values= ['Serdivan AVM Sinemaları']
}

enum ExpandIcon{
    Menu='menu',
    Close='close'
}

enum ExpandPosition{
    Show = 'tw-top-[67px]',
    Hide = 'tw-top-[-60%] '
}