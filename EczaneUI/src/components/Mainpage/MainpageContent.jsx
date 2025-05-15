import { useEffect, useState } from "react";
import IlacList from "../Ilac/IlacList";
import IlacSearch from "../Ilac/IlacSearch";
import "./MainpageContent.css";
import GetIlaclar from "../../api/GetIlaclar";
import GetSatislar from "../../api/GetSatislar";
import Satislar from "../Satislar/Satislar";

const MainpageContent = ({
        pageKey, ilaclar, setIlaclar, checkedList, setCheckedList, satislar, setSatislar
    }) => {
    const [filteredList, setFilteredList] = useState([]);

    useEffect(() => {console.log(checkedList)},[checkedList])

    useEffect(() => {
        const fetchSatislar = async () => {
            const resultSatislar = await GetSatislar();
            setSatislar(resultSatislar);
        }

        fetchSatislar();
    },[setSatislar])

    useEffect( () => {
        const fetchIlaclar = async () => {
            const response = await GetIlaclar();
            const ilaclarList = response;
            console.log(ilaclarList);
            setIlaclar(ilaclarList);
            setFilteredList(ilaclarList);
        }
        fetchIlaclar();
    },[setIlaclar])

    switch(pageKey){
        case "1":
            return (
                <div className="anasayfa-content">
                    <h1>Merhaba</h1>    
                </div>
            );
        case "2":
            return (
                <div className="ilaclar-content">
                    <IlacSearch 
                        ilaclar={ilaclar}
                        filteredList={filteredList} 
                        setFilteredList={setFilteredList} 
                    />
                    <IlacList 
                        checkedList={checkedList} 
                        setCheckedList={setCheckedList} 
                        filteredList={filteredList}
                        ilaclar={ilaclar}
                        setIlaclar={setIlaclar}
                        setFilteredList={setFilteredList}
                    />
                </div>
            );
        case "3":
            return(
                <div className="satislar-content">
                    <Satislar satislar={satislar}></Satislar>
                </div>    
            );
        case "4":
            return (
                <div className="raporlama-content">
                    <h1>Raporlama</h1>
                </div>
            );
    }
}

export default MainpageContent;