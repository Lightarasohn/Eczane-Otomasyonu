import Search from "antd/es/input/Search";
import "./IlacSearch.css";
import { useEffect } from "react";

const IlacSearch = ({ilaclar, setFilteredList}) => {

    const onSearch = (value) => {
    if (value === "") {
      setFilteredList(ilaclar);
    } else {
      const filtered = ilaclar.filter((ilac) => 
        ilac.adi.toLowerCase().includes(value.toLowerCase()));
      setFilteredList(filtered);
    }
  };

  const handleOnChange = (val) => {
    if(val === ""){
      setFilteredList(ilaclar)
    }
  }

  useEffect(() => {
    setFilteredList(ilaclar)
  },[ilaclar, setFilteredList])

    return (
        <Search
      placeholder="ilaç"
      allowClear
      size="large"
      enterButton
      onSearch={(value) => onSearch(value)}
      onChange={(val) => handleOnChange(val.target.value)}
      style={{
        width: 400,
        margin: "0 auto",
        marginTop: "20px",
      }}
    />
    );
}

export default IlacSearch;