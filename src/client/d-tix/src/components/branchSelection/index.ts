import { Component, Prop } from 'vue-property-decorator';
import Base from "@/utils/Base";
import { Repositories, RepositoryFactory } from "@/services/RepositoryFactory";
import { MovieRepository } from "@/Repositories/MovieRepository";
import MovieDto from "@/models/movies/MovieDto";
import MovieSelectionCard from "@/components/movieSelection/movieSelectionCard/index.vue";
import BranchDto from '@/models/branch/BranchDto';
import { BranchRepository } from '@/Repositories/BranchRepository';
import CityDto from '@/models/city/CityDto';
import DistrinctDto from '@/models/distrinct/DistrinctDto';
import { CityRepository } from '@/Repositories/CityRepository';
import { DistrinctRepository } from '@/Repositories/DistrinctRepository';
import BranchSelectionCard from './branchSelectionCard/index.vue';

const _cityRepository = RepositoryFactory(Repositories.CityRepository) as CityRepository;
const _distrinctRepository = RepositoryFactory(Repositories.DistrinctRepository) as DistrinctRepository;
const _branchRepository = RepositoryFactory(Repositories.BranchRepository) as BranchRepository;

interface BranchSelectionCardModel {
    branch: BranchDto;
    isSelected: boolean;
}

@Component({
    components: {
        BranchSelectionCard
    }
})
export default class BranchSelection extends Base {
    @Prop({default: null}) branchId!: number;

    cities: CityDto[] = [];
    city = new CityDto();

    districts: DistrinctDto[] = [];
    district = new DistrinctDto();

    branchSelectionCardDatas: BranchSelectionCardModel[] = [];
    itemCount: number = 0;

    created(): void {
        this.showLoading();
        _cityRepository.GetAllCities()
            .then((r) => {
                this.cities = r;
            })
            .finally(() => this.hideLoading());
    }

    cityChanged(event: any) {      
        if(event > 0) {
            this.districts = [];
            this.showLoading();
            _distrinctRepository.GetDistrictByCity(event.toString())
                .then((r) => {
                    this.districts = r;
                })
                .finally(() => this.hideLoading());
        }
        this.districts = [];
    }

    distrinctChanged(event: any) {
        if(event > 0) {
            this.branchSelectionCardDatas = [];
            this.showLoading();
            _branchRepository.GetBranchesByDistrinct(event.toString())
                .then((r) => {
                    r.forEach(item => {
                        this.branchSelectionCardDatas.push({
                            branch :item,
                            isSelected : false,
                        });
                    });
                })
                .finally(() => this.hideLoading());
        }
        this.branchSelectionCardDatas = [];
    }

    destroyed(): void {
    }

    mounted(): void {
        if(this.branchId > 0) {
            this.showLoading();
            _branchRepository.GetBrancheById(this.branchId.toString())
                .then((r) => {
                    this.city = r.district.city;
                    this.cityChanged(this.city.id);
                    this.district = r.district;
                    this.distrinctChanged(this.district.id);
                    setTimeout(() => {
                        this.selectBranch(this.branchId);
                    }, 1000);
                })
                .finally(() => this.hideLoading());            
        }
    }

    selectBranch(id: number) {
        let oldSelectionBranch = this.branchSelectionCardDatas.find(x => x.isSelected);
        let newSelectionBranch = this.branchSelectionCardDatas.find(x => x.branch.id == id);

        if (!oldSelectionBranch && newSelectionBranch) {
            newSelectionBranch.isSelected = true;
            this.$emit('selectBranchForReservation', id);
            return;
        }

        if (oldSelectionBranch && newSelectionBranch) {
            if (oldSelectionBranch.branch.id == newSelectionBranch.branch.id) {
                return;
            } else {
                oldSelectionBranch.isSelected = false;
                newSelectionBranch.isSelected = true;
                this.$emit('selectBranchForReservation', id)
            }
        }
        return;
    }
}