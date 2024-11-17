import {Component} from 'vue-property-decorator';
import CategoryCard from '@/components/categoryCard/index.vue';
import Base from "@/utils/Base";
import {Repositories, RepositoryFactory} from "@/services/RepositoryFactory";
import {CategoryRepository} from "@/Repositories/CategoryRepository";
import CategoryDto from "@/models/categories/CategoryDto";


const _categoryRepository = RepositoryFactory(Repositories.CategoryRepository) as CategoryRepository;
@Component({
    components: {
        CategoryCard,
    }
})
export default class Categories extends Base {
    categories: CategoryDto[] =  [];

    created(){
        const self = this;
        this.showLoading()
        _categoryRepository.GetAllCategories()
            .then(r => {
                    this.categories = r;
            })
            .finally(()=> self.hideLoading());
    }
    mounted(){

    }
    destroyed(){

    }

}