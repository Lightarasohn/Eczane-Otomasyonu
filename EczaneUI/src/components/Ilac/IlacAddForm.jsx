import { Button, Form, Input, InputNumber } from "antd";
import "./IlacAddForm.css"
import AddIlac from "../../api/AddIlac";
import GetIlaclar from "../../api/GetIlaclar";

const IlacAddForm = ({setModalOpen, isSuccess, setIsSuccess, setIlaclar, ilaclar}) => {
    

    const handleOnSubmit = async (values) => {
        const response = await AddIlac(values)
        if(response !== null){
            setIlaclar([...ilaclar, values])
            setIsSuccess(true);
        }
    }

    return(
        <>
        <Form onFinish={handleOnSubmit}>
            <Form.Item name="adi" style={{width:"150px"}}>
                <Input
                placeholder="ilac adi"
                required
                onChange={() => setIsSuccess(false)}>
                </Input>
            </Form.Item>
            <Form.Item
  name="fiyati"
  rules={[
    { required: true, message: "Fiyat girilmelidir" },
    {
      validator: (_, value) =>
        value > 0
          ? Promise.resolve()
          : Promise.reject("Fiyat 0'dan büyük olmalıdır"),
    },
  ]}
>
  <InputNumber placeholder="10" onChange={() => setIsSuccess(false)}/>
</Form.Item>

<Form.Item
  name="stokDurumu"
  rules={[
    { required: true, message: "Stok girilmelidir" },
    {
      validator: (_, value) =>
        value > 0
          ? Promise.resolve()
          : Promise.reject("Stok 0'dan büyük olmalıdır"),
    },
  ]}
>
  <InputNumber placeholder="100" onChange={() => setIsSuccess(false)}/>
</Form.Item>

            <Button
            htmlType="submit"
            type="primary">
                İlaci Ekle
            </Button>
            <Button
            type="primary" danger onClick={() => {setModalOpen(false); setIsSuccess(false)}}>
                Çık
            </Button>
        </Form>
        {isSuccess ? <h1 color="green">İlac eklendi</h1>: <></>}
        </>
    );
}

export default IlacAddForm;