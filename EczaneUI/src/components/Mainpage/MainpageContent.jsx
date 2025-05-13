import { useEffect, useState } from "react";
import IlacList from "../Ilac/IlacList";
import IlacSearch from "../Ilac/IlacSearch";
import "./MainpageContent.css";
import GetIlaclar from "../../api/GetIlaclar";

const MainpageContent = ({pageKey, ilaclar, setIlaclar}) => {
    
    const [checkedList, setCheckedList] = useState([]);
    const [filteredList, setFilteredList] = useState([]);

    

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
                    />
                </div>
            );
        case "3":
            return (
                <div className="raporlama-content">
                    <h1>Raporlama</h1>
                </div>
            );
    }
}

export default MainpageContent;