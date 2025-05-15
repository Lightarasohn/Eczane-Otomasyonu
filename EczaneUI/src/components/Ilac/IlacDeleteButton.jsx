import { Button } from "antd";
import "./IlacDeleteButton.css"
import { DeleteOutlined } from '@ant-design/icons';

const IlacDeleteButton = ({onDeleteButtonClick}) => {

    return(
        <Button className="item-delete-button"
        type="primary" danger 
        icon={<DeleteOutlined />}  
        onClick={onDeleteButtonClick}></Button>
    );
}

export default IlacDeleteButton;