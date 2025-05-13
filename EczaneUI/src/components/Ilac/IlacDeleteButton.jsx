import { Button } from "antd";
import "./IlacDeleteButton.css"
import { DeleteOutlined } from '@ant-design/icons';

const IlacDeleteButton = () => {

    return(
        <Button className="item-delete-button"
        type="primary" danger icon={<DeleteOutlined />}  ></Button>
    );
}

export default IlacDeleteButton;