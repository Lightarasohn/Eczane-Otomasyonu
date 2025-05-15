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
        pageSize: 4,
        showSizeChanger: false,
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
