import CityDto from "@/models/city/CityDto";

export default class DistrinctDto{
    id: number;
    name: string;
    cityId: number;
    city:CityDto;
}