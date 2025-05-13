import { Descriptions, List } from "antd";
import "./IlacList.css";
import Ilac from "./Ilac";

const IlacList = ({checkedList, setCheckedList, filteredList}) => {
    

    return (
        <List
            className="ilac-list"
            itemLayout="horizontal"
            dataSource={filteredList}
            renderItem={(item) => (
                <Ilac ilac={item}
                      checkedList={checkedList}
                      setCheckedList={setCheckedList}
                />
            )}
        />
    );
}

export default IlacList;