import { Descriptions, List } from "antd";
import "./IlacList.css";
import Ilac from "./Ilac";

const IlacList = ({
  checkedList,
  setCheckedList,
  filteredList,
  ilaclar,
  setIlaclar,
  setFilteredList,
}) => {
  return (
    <List
      pagination={{
        pageSize: 4, // ✅ Her sayfada maksimum 4 öğe göster
        showSizeChanger: false, // Kullanıcının sayfa başına öğe sayısını değiştirmesini engelle
      }}
      className="ilac-list"
      itemLayout="horizontal"
      dataSource={filteredList}
      renderItem={(item) => (
        <Ilac
          ilac={item}
          ilaclar={ilaclar}
          setIlaclar={setIlaclar}
          setFilteredList={setFilteredList}
          filteredList={filteredList}
          checkedList={checkedList}
          setCheckedList={setCheckedList}
        />
      )}
    />
  );
};

export default IlacList;
